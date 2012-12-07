#!/usr/bin/env python
# -*- coding: utf-8 -*-

from django.db import models
from django.contrib.auth.models import User
import urllib
from si_demeter import settings

class Usuario(User):
    def __unicode__(self):
        return self.username

class Fazenda(models.Model):
    usuario = models.ForeignKey(Usuario)
    nome_fazenda = models.CharField("Nome da Fazenda" ,max_length=128)
    descricao_fazenda = models.TextField("Descricao", max_length=1024, blank=True, null=True)
    endereco = models.CharField("Endereco", max_length=1024, blank=True, null=True)
    latitude = models.FloatField("Latitude", blank=True, null=True)
    longitude = models.FloatField("Latitude", blank=True, null=True)

    def __unicode__(self):
        return self.nome_fazenda
    
    def get_latitude(self):
        key = settings.GOOGLE_API_KEY
        output = "csv"
        location = urllib.quote_plus(self.endereco)
        request = "http://maps.google.com/maps/geo?q=%s&output=%s&key=%s" % (location, output, key)
        data = urllib.urlopen(request).read()
        dlist = data.split(',')
        if dlist[0] == '200':
            latitude = dlist[2]
            return latitude
            #lon = dlist[3]
            #return "%s, %s" % (dlist[2], dlist[3])
        else:
            return ''
        
    def get_longitude(self):
        key = settings.GOOGLE_API_KEY
        output = "csv"
        location = urllib.quote_plus(self.endereco)
        request = "http://maps.google.com/maps/geo?q=%s&output=%s&key=%s" % (location, output, key)
        data = urllib.urlopen(request).read()
        dlist = data.split(',')
        if dlist[0] == '200':
            longitude = dlist[3]
            return longitude
        else:
            return ''

class Setor(models.Model):
    fazenda = models.ForeignKey(Fazenda)
    regiao_setor = models.CharField("Regiao do Setor", max_length=128) #colocar choice?
    cultura_setor = models.CharField("Cultura do Setor", max_length=128) #colocar choice?
    descricao_setor = models.CharField("Descricao do Setor", max_length=1024, blank=True, null=True)
    id_modulo = models.IntegerField("ID do Modulo", max_length=1024, blank=True, null=True)
    valor_referencia = models.FloatField("Valor de Referencia", blank=True, null=True)
    latitude = models.FloatField("Latitude", blank=True, null=True)
    longitude = models.FloatField("Latitude", blank=True, null=True)

    def __unicode__(self):
        return self.id_modulo
    
    def calcula_media(self):
        lista_historico_setor = HistoricoSetor.objects.filter(id_modulo=self.id_modulo)
        soma = 0
        i = 1.0
        media = 0
        for historico_setor in lista_historico_setor:
            soma = soma + historico_setor.valor_medida
            media = soma/i
            i = i + 1
        return media
    
    #retorna verdadeiro se a ultima medida está maior que a refrencia
    def compara_medida_referencia(self):
        lista_historico_setor = HistoricoSetor.objects.filter(id_modulo=self.id_modulo)
        if lista_historico_setor == None:
            ultimo_historico = lista_historico_setor.order_by("-data_medida")[0]
            ultima_medida = ultimo_historico.valor_medida
        else:
            ultima_medida = 0
        if ultima_medida >= self.valor_referencia:
            return True
        else:
            return False
        
    #retorna verdadeiro se a media está maior que a referencia
    def compara_media_referencia(self):
        if self.calcula_media() >= self.valor_referencia:
            return True
        else:
            return False
    
class HistoricoSetor(models.Model):
    id_modulo = models.IntegerField("ID do Modulo", max_length=1024, blank=True, null=True)
    id_sensor = models.CharField("ID do Sensor", max_length=1024, blank=True, null=True)
    data_medida = models.DateTimeField("Data da Medida")
    valor_medida = models.FloatField("Valor da Medida", blank=True, null=True)
    tipo_sensor = models.CharField("Tipo do Sensor", max_length=1024, blank=True, null=True) #colocar choice?

    def __unicode__(self):
        return self.id_modulo
    
class Contato(models.Model):
    usuario = models.ForeignKey(Usuario)
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