#!/usr/bin/env python
# -*- coding: utf-8 -*-

from django.db import models
from django.contrib.auth.models import User

class Usuario(User):
    def __unicode__(self):
        return self.username

class Fazenda(models.Model):
    usuario = models.ForeignKey(Usuario)
    nome_fazenda = models.CharField("Nome da Fazenda" ,max_length=128)
    descricao_fazenda = models.CharField("Descricao", max_length=1024, blank=True, null=True)
    endereco = models.CharField("Endereco", max_length=1024, blank=True, null=True)
    cidade = models.CharField("Cidade", max_length=1024) #colocar choice
    estado = models.CharField("Estado", max_length=1024) #colocar choice
    data_visualizacao = models.DateTimeField("Ultima Visualizacao", blank=True, null=True)
    data_modificacao = models.DateTimeField("Ultima Modificacao", blank=True, null=True)

    def __unicode__(self):
        return self.nome_fazenda

class Setor(models.Model):
    fazenda = models.ForeignKey(Fazenda)
    numero_setor = models.CharField("Numero do Setor", max_length=128)
    cultura_setor = models.CharField("Cultura do Setor", max_length=128) #colocar choice
    descricao_setor = models.CharField("Descricao do Setor", max_length=1024, blank=True, null=True)

    def __unicode__(self):
        return self.nome_setor
    
class HistoricoSetor(models.Model):
    setor = models.ForeignKey(Setor)
    data_medida = models.DateField("Data da Medida")
    id_modulo = models.CharField("ID do Modulo", max_length=1024, blank=True, null=True)
    medida1 = models.CharField("Medida 1", max_length=1024, blank=True, null=True)
    medida2 = models.CharField("Medida 2", max_length=1024, blank=True, null=True)
    medida3 = models.CharField("Medida 3", max_length=1024, blank=True, null=True)
    medida4 = models.CharField("Medida 4", max_length=1024, blank=True, null=True)
    media_dia = models.CharField("Média do Dia", max_length=1024, blank=True, null=True)

    def __unicode__(self):
        return self.setor
    
    def calcula_media(self):
        soma = self.medida1+self.medida2+self.medida3+self.medida4
        media = soma/4
        self.media_dia = media
        return media
    
class Contato(models.Model):
    fazenda = models.ForeignKey(Fazenda)
    nome_contato = models.CharField("Nome do Contato" ,max_length=128)
    descricao_contato = models.CharField("Descricao", max_length=1024, blank=True, null=True)
    telefone = models.CharField("Telefone", max_length=1024, blank=True, null=True)

    def __unicode__(self):
        return self.nome_contato
#    
#class Tempo(models.Model):
#    fazenda = models.ForeignKey(Fazenda)
#    data_medidao = models.DateTimeField("Data da Medida")
#    medida = models.CharField("Medida Tempo", max_length=1024, blank=True, null=True)
#
#    def __unicode__(self):
#        return self.fazenda
#    
#class Umidade(models.Model):
#    fazenda = models.ForeignKey(Fazenda)
#    data_medidao = models.DateTimeField("Data da Medida")
#    medida = models.CharField("Medida Tempo", max_length=1024, blank=True, null=True)
#
#    def __unicode__(self):
#        return self.fazenda
#    
#class Evento(models.Model):
#    fazenda = models.ForeignKey(Fazenda)
#    data_evento = models.DateTimeField("Data do Evento")
#    descricao_evento = models.CharField("Descricao", max_length=1024, blank=True, null=True)
#
#    def __unicode__(self):
#        return self.fazenda