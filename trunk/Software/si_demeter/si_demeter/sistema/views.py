#!/usr/bin/env python
# -*- coding: utf-8 -*-

from django.db import models
from django.forms import ModelForm
from django.contrib.auth.models import User
from django import forms
from django.http import HttpResponseRedirect, HttpResponse
from django.core.urlresolvers import reverse
from django.contrib.auth.decorators import login_required
from django.contrib.auth import logout, authenticate, login
from django.contrib.auth import login as auth_login
from django.contrib.auth import logout as auth_logout
from django.contrib.auth import authenticate
from django.template import RequestContext
from django.utils.http import urlencode
from django.shortcuts import render_to_response, get_object_or_404, get_list_or_404
from django.conf import settings
from django.contrib import messages


from si_demeter.sistema.models import *
from si_demeter.sistema.forms import *

#INICIO
def login(request):
    var_login_inativo = False
    var_login_incorreto = False
    if request.method == 'POST':
        login_form = LoginForm(request.POST)
        if login_form.is_valid():
            usuario = login_form.cleaned_data['username']
            senha = login_form.cleaned_data['password']
            user = authenticate(username=usuario, password=senha)
            if user is not None:
                if user.is_active:
                    auth_login(request, user)
                    url = reverse('inicio')
                    return HttpResponseRedirect(url)
                else:
                    var_login_inativo = True
                    return render_to_response('login.html', locals(), context_instance=RequestContext(request) )
            else:
                var_login_incorreto = True
                return render_to_response('login.html', locals(), context_instance=RequestContext(request) )
        else:
            return render_to_response('login.html', locals(), context_instance=RequestContext(request) )
    else:
        login_form = LoginForm()
        return render_to_response('login.html', locals(), context_instance=RequestContext(request) )
            
@login_required
def logout(request):
    auth_logout(request)
    url = reverse('login')
    return HttpResponseRedirect(url)

@login_required
def inicio(request):
    usuario = Usuario.objects.get(username=request.user.username)
    fazendas = Fazenda.objects.filter(usuario=usuario)
    if fazendas:
        pass
    else:
        url = reverse('cria_fazenda')
        return HttpResponseRedirect(url)
    return render_to_response('inicio.html', locals(), context_instance=RequestContext(request))
 #/INICIO   
    
    
#FAZENDA
@login_required
def cria_fazenda(request):
    usuario = Usuario.objects.get(username=request.user.username)
    fazenda = Fazenda()
    fazenda.usuario = usuario
    if request.method == 'POST':
        fazenda_form = FazendaForm(request.POST, instance=fazenda)
        if fazenda_form.is_valid():
            fazenda = fazenda_form.save()
            #messages.add_message(request, messages.SUCCESS, 'Fazenda criada com sucesso.')
            url = reverse('inicio')
            return HttpResponseRedirect(url)
        else:
            messages.add_message(request, messages.ERROR, 'Problema paracriar fazenda.')
            return render_to_response('cria_fazenda.html', locals(), context_instance=RequestContext(request) )
    else:
        fazenda_form = FazendaForm(instance=fazenda)
        return render_to_response('cria_fazenda.html', locals(), context_instance=RequestContext(request) )
        
@login_required
def fazenda(request, id_fazenda):
    usuario = Usuario.objects.get(username=request.user.username)
    fazenda = Fazenda.objects.get(id=id_fazenda)
    fazenda.usuario = usuario
    if request.method == 'POST':
        fazenda_form = FazendaForm(request.POST, instance=fazenda)
        if fazenda_form.is_valid():
            #latitude = fazenda_form.cleaned_data['latitude']
            #return HttpResponse(latitude)
            fazenda = fazenda_form.save()
            messages.add_message(request, messages.SUCCESS, 'Fazenda editada com sucesso.')
            url = reverse('fazenda', args=[fazenda.id])
            return HttpResponseRedirect(url)
        else:
            messages.add_message(request, messages.ERROR, 'Problema para editar fazenda.')
            return render_to_response('fazenda.html', locals(), context_instance=RequestContext(request) )
    else:
        fazenda_form = FazendaForm(instance=fazenda)
        setores = Setor.objects.filter(fazenda=fazenda)
        contatos = Contato.objects.filter(fazenda=fazenda)
        return render_to_response('fazenda.html', locals(), context_instance=RequestContext(request) )
    return render_to_response('fazenda.html', locals(), context_instance=RequestContext(request) )
    
@login_required
def exclui_fazenda(request, id_fazenda):
        usuario = Usuario.objects.get(username=request.user.username)
        fazenda = Fazenda.objects.get(id=id_fazenda)
        fazenda.delete()
        #messages.add_message(request, messages.SUCCESS, 'Fazenda excluida com sucesso.')
        url = reverse('inicio')
        return HttpResponseRedirect(url)  
#/FAZENDA    
    
#SETOR
@login_required
def cria_setor(request, id_fazenda):
    usuario = Usuario.objects.get(username=request.user.username)
    fazenda = Fazenda.objects.get(id=id_fazenda)
    setor = Setor()
    setor.fazenda = fazenda
    if request.method == 'POST':
        setor_form = SetorForm(request.POST, instance=setor)
        if setor_form.is_valid():
            setor = setor_form.save()
            messages.add_message(request, messages.SUCCESS, 'Setor criado com sucesso.')
            url = reverse('edita_setor_mapa', args=[fazenda.id, setor.id])
            return HttpResponseRedirect(url)
        else:
            messages.add_message(request, messages.ERROR, 'Problema para criar setor.')
            return render_to_response('cria_setor.html', locals(), context_instance=RequestContext(request) )
    else:
        setor_form = SetorForm(instance=setor)
        return render_to_response('cria_setor.html', locals(), context_instance=RequestContext(request) )
        
@login_required
def setor(request, id_fazenda, id_setor):
    usuario = Usuario.objects.get(username=request.user.username)
    fazenda = Fazenda.objects.get(id=id_fazenda)
    setor = Setor.objects.get(id=id_setor)
    if request.method == 'POST':
        setor_form = SetorForm(request.POST, instance=setor)
        if setor_form.is_valid():
            setor = setor_form.save()
            messages.add_message(request, messages.SUCCESS, 'Setor editado com sucesso.')
            url = reverse('setor', args=[fazenda.id, setor.id])
            return HttpResponseRedirect(url)
        else:
            messages.add_message(request, messages.ERROR, 'Problema para editar setor.')
            return render_to_response('setor.html', locals(), context_instance=RequestContext(request) )
    else:
        setor_form = SetorForm(instance=setor)
        id_modulo = setor.id_modulo
        lista_historico_setor = HistoricoSetor.objects.filter(id_modulo=id_modulo)
        var_grafico_terra = []
        var_interno = []
        i = 1.0
        soma = 0
        for historico_setor in lista_historico_setor:
            var_interno = [i, historico_setor.valor_medida]
            soma = soma + historico_setor.valor_medida
            var_media_terra = soma/i
            var_grafico_terra.append(var_interno)
            i = i + 1
            datahora = historico_setor.data_medida
        d10=[[1,10],[2,20], [3,30]]
        return render_to_response('setor.html', locals(), context_instance=RequestContext(request) )
    return render_to_response('setor.html', locals(), context_instance=RequestContext(request) )
    
@login_required
def edita_setor_mapa(request, id_fazenda, id_setor):
        usuario = Usuario.objects.get(username=request.user.username)
        fazenda = Fazenda.objects.get(id=id_fazenda)
        setor = Setor.objects.get(id=id_setor)
        if request.is_ajax():
            setor.latitude = request.POST['latitude']
            setor.longitude = request.POST['longitude']
            setor.save()
            return HttpResponse('Posição alterada com sucesso.')
        else:
            return render_to_response('edita_setor_mapa.html', locals(), context_instance=RequestContext(request) )
    
@login_required
def exclui_setor(request, id_fazenda, id_setor):
        usuario = Usuario.objects.get(username=request.user.username)
        fazenda = Fazenda.objects.get(id=id_fazenda)
        setor = Setor.objects.get(id=id_setor)
        setor.delete()
        messages.add_message(request, messages.SUCCESS, 'Setor excluido com sucesso.')
        url = reverse('fazenda', args=[fazenda.id])
        return HttpResponseRedirect(url) 
#/SETOR

#CONTATO
@login_required
def contatos(request):
    contatos = Contato.objects.all()
    lista_contatos = []
    for contato in contatos:
        lista_contatos.append(ContatoForm(instance=contato))
    return render_to_response('contatos.html', locals(), context_instance=RequestContext(request) )
    
@login_required
def cria_contato(request):
    contato = Contato()
    if request.method == 'POST':
        contato_form = ContatoForm(request.POST, instance=contato)
        if contato_form.is_valid():
            contato = contato_form.save()
            messages.add_message(request, messages.SUCCESS, 'Contato criado com sucesso.')
            url = reverse('contatos', args=[fazenda.id])
            return HttpResponseRedirect(url)
        else:
            messages.add_message(request, messages.SUCCESS, 'Problema para criar contato.')
            return render_to_response('cria_contato.html', locals(), context_instance=RequestContext(request) )
    else:
        contato_form = ContatoForm(instance=contato)
        return render_to_response('cria_contato.html', locals(), context_instance=RequestContext(request) )   
    
@login_required
def edita_contato(request, id_contato):
    contato = Contato.objects.get(id=id_contato)
    if request.method == 'GET':
        contato_form = ContatoForm(instance=contato)
    else:
        contato_form = ContatoForm(request.POST, instance=contato)
        if contato_form.is_valid():
            contato_form.save()
            messages.add_message(request, messages.SUCCESS, 'Contato modificado com sucesso.')
        else:
            messages.add_message(request, messages.ERROR, 'Problema para editar contato.')
            error = True
    url = reverse('contatos', args=[fazenda.id])
    return HttpResponseRedirect(url)
    
@login_required
def exclui_contato(request, id_contato):
        contato = Contato.objects.get(id=id_contato)
        contato.delete()
        messages.add_message(request, messages.SUCCESS, 'Contato excluido com sucesso.')
        url = reverse('contatos', args=[fazenda.id])
        return HttpResponseRedirect(url)  
#/CONTATO 