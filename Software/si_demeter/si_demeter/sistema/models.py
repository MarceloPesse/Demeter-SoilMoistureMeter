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
    regiao_setor = models.CharField("Regiao do Setor", max_length=128) #colocar choice?
    cultura_setor = models.CharField("Cultura do Setor", max_length=128) #colocar choice?
    descricao_setor = models.CharField("Descricao do Setor", max_length=1024, blank=True, null=True)
    id_modulo = models.IntegerField("ID do Modulo", max_length=1024, blank=True, null=True)

    def __unicode__(self):
        return self.id_modulo
    
class HistoricoSetor(models.Model):
    #setor = models.ForeignKey(Setor)
    id_modulo = models.IntegerField("ID do Modulo", max_length=1024, blank=True, null=True)
    data_medida = models.DateTimeField("Data da Medida")
    valor_medida = models.FloatField("Valor da Medida", blank=True, null=True)
    tipo_sensor = models.CharField("Tipo do Sensor", max_length=1024, blank=True, null=True) #colocar choice?

    def __unicode__(self):
        return self.id_modulo
    
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