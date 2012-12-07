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

def context_principal(request):
    a = 1
    if request.user.is_authenticated():
        usuario = Usuario.objects.get(username=request.user.username)
        fazendas = Fazenda.objects.filter(usuario=usuario)
    return locals()
