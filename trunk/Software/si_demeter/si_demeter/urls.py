#!/usr/bin/env python
# -*- coding: utf-8 -*-


from django.conf.urls import patterns, include, url
from django.conf.urls.defaults import *
from django.conf import settings
import os


# Uncomment the next two lines to enable the admin:
from django.contrib import admin
admin.autodiscover()

urlpatterns = patterns('',
    # Examples:
    # url(r'^$', 'si_demeter.views.home', name='home'),
    # url(r'^si_demeter/', include('si_demeter.foo.urls')),

    # Uncomment the admin/doc line below to enable admin documentation:
    # url(r'^admin/doc/', include('django.contrib.admindocs.urls')),

    # Uncomment the next line to enable the admin:
    url(r'^admin/', include(admin.site.urls)),
    
    #url(r'^si_demeter/', include('si_demeter.sistema.urls')),
    
    #GERAL
    url(r'^$', 'django.views.generic.simple.redirect_to', {'url': 'inicio/'}),
    url(r'^login/$', 'si_demeter.sistema.views.login', name='login'),
    url(r'^logout/$', 'si_demeter.sistema.views.logout', name='logout'),
    url(r'^inicio/$', 'si_demeter.sistema.views.inicio', name='inicio'),
    
    #FAZENDA
    url(r'^cria_fazenda/$', 'si_demeter.sistema.views.cria_fazenda', name='cria_fazenda'),
    url(r'^fazenda/(?P<id_fazenda>[A-Za-z0-9]+)/$', 'si_demeter.sistema.views.fazenda', name='fazenda'),
    url(r'^exclui_fazenda/(?P<id_fazenda>[A-Za-z0-9]+)/$', 'si_demeter.sistema.views.exclui_fazenda', name='exclui_fazenda'),
    
    #SETOR
    url(r'^fazenda/(?P<id_fazenda>[A-Za-z0-9]+)/cria_setor/$', 'si_demeter.sistema.views.cria_setor', name='cria_setor'),
    url(r'^fazenda/(?P<id_fazenda>[A-Za-z0-9]+)/setor/(?P<id_setor>[A-Za-z0-9]+)/$', 'si_demeter.sistema.views.setor', name='setor'),
    url(r'^fazenda/(?P<id_fazenda>[A-Za-z0-9]+)/edita_setor_mapa/(?P<id_setor>[A-Za-z0-9]+)/$', 'si_demeter.sistema.views.edita_setor_mapa', name='edita_setor_mapa/'),
    url(r'^fazenda/(?P<id_fazenda>[A-Za-z0-9]+)/exclui_setor/(?P<id_setor>[A-Za-z0-9]+)/$', 'si_demeter.sistema.views.exclui_setor', name='exclui_setor'),
    
    #CONTATO
    url(r'^contatos/$', 'si_demeter.sistema.views.contatos', name='contatos'),
    url(r'^cria_contato/$', 'si_demeter.sistema.views.cria_contato', name='cria_contato'),
    url(r'^edita_contato/(?P<id_contato>[A-Za-z0-9]+)/$', 'si_demeter.sistema.views.edita_contato', name='edita_contato'),
    url(r'^exclui_contato/(?P<id_contato>[A-Za-z0-9]+)/$', 'si_demeter.sistema.views.exclui_contato', name='exclui_contato'),
    
    
    
    #Localmente
    url(r'^static/(?P<path>.*)$', 'django.views.static.serve',
            {'document_root': os.path.join(os.getcwd(),'static') }),
    url(r'^arquivos/(?P<path>.*)$', 'django.views.static.serve',
            {'document_root': os.path.join(os.getcwd(),'arquivos') }),
)
