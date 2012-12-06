#!/usr/bin/env python
# -*- coding: utf-8 -*-

from django.forms import ModelForm
from django import forms
from django.contrib.localflavor.br.forms import *

from si_demeter.sistema.models import *

class LoginForm(forms.Form):
    username = forms.CharField(max_length=64)
    password = forms.CharField(max_length=64, widget=forms.PasswordInput)

class FazendaForm(forms.ModelForm):
    class Meta:
        model = Fazenda
        exclude = ('usuario', 'latitude', 'longitude')
        
class SetorForm(forms.ModelForm):
    class Meta:
        model = Setor
        exclude = ('fazenda', 'latitude', 'longitude')
        
class ContatoForm(forms.ModelForm):
    class Meta:
        model = Contato