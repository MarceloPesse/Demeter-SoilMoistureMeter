# -*- coding: utf-8 -*-
from django import template
from si_demeter.sistema.models import *

register = template.Library()

@register.filter
def lista_setores(fazenda):
    setores = Setor.objects.filter(fazenda=fazenda)
    return setores
    
register.filter('lista_setores', lista_setores)