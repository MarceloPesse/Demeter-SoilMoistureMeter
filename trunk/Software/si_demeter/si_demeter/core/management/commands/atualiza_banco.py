# -*- coding: utf-8 -*-

from django.core.management.base import NoArgsCommand
from django.contrib.auth.models import User
from si_demeter.sistema.models import *
from django.utils.timezone import *
from datetime import date


class Command(NoArgsCommand):
    help = """Cria Groupos"""

    requires_model_validation = 0

    def handle_noargs(self, **options):
        
        def cria_usuario(username, password):
            usuario = Usuario(username=username, email=username+'@gmail.com')
            usuario.set_password(password)
            usuario.save()
            #usuario = User.objects.create_user(username=username, password=password, email=username+'@gmail.com')
            return usuario
            
        def cria_usuario_admin(username, password):
            usuario2 = cria_usuario(username, password)
            usuario2.is_staff = True
            usuario2.is_active = True
            usuario2.is_superuser = True
            usuario2.save()
            return usuario2
        
        usuario1 = cria_usuario('tones', 'tones')
        #usuario = User.objects.create_user(username='tones', password='tonesp', email='jhonston@gmail.com')
        admin1 = cria_usuario_admin('admin', 'admin')
        
        def cria_fazenda(usuario, nome_fazenda, descricao_fazenda, endereco):
            fazenda = Fazenda(usuario=usuario, nome_fazenda=nome_fazenda, descricao_fazenda=descricao_fazenda, endereco=endereco)
            fazenda.save()
            return fazenda
        
        fazenda1 = cria_fazenda(usuario1, 'Fazenda Fruto da Terra', 'Fazenda criada em 1965, terra vermelha e muito sol.', 'av. professor melo moraes 1235 - butanta - sao paulo')
        fazenda2 = cria_fazenda(usuario1, 'Fazenda Amanhecer', 'Fazenda criada em 1965, terra vermelha e muito sol.', 'av. professor melo moraes 1235 - butanta - sao paulo')
        
        def cria_setor(fazenda, regiao_setor, cultura_setor, descricao_setor, id_modulo, valor_referencia, latitude, longitude):
            setor = Setor(fazenda=fazenda, regiao_setor=regiao_setor, cultura_setor=cultura_setor, descricao_setor=descricao_setor, id_modulo=id_modulo,
                          valor_referencia=valor_referencia, latitude=latitude, longitude=longitude)
            setor.save()
            return setor
        
        setor1 = cria_setor(fazenda1, 'Norte da Fazenda', 'Arroz', 'Arroz de exportação', 123, 13.0, -23.558, -46.722)
        setor2 = cria_setor(fazenda1, 'Sul da Fazenda', 'Milho', 'Milho de exportação', 124, 12.0, -23.566, -46.734)
        setor3 = cria_setor(fazenda2, 'Sul da Fazenda', 'Café', 'Café de exportação', 234, 11.0, -23.557299699999774, -46.72210693359375)
        
        def cria_historico_setor(id_modulo, data_medida, valor_medida, tipo_sensor):
            historico_setor = HistoricoSetor(id_modulo=id_modulo, data_medida=data_medida, valor_medida=valor_medida, tipo_sensor=tipo_sensor)
            historico_setor.save()
            return historico_setor
        
        historico_setor1 = cria_historico_setor(123, '2012-05-10', 10.0, 'Umidade da Terra')
        historico_setor2 = cria_historico_setor(123, '2012-06-10', 15.0, 'Umidade da Terra')
        historico_setor2 = cria_historico_setor(123, '2012-07-10', 20.0, 'Umidade da Terra')
        historico_setor2 = cria_historico_setor(123, '2012-08-10', 15.0, 'Umidade da Terra')
        historico_setor2 = cria_historico_setor(123, '2012-09-10', 10.0, 'Umidade da Terra')
        historico_setor3 = cria_historico_setor(124, '2012-06-10', 10.0, 'Umidade da Terra')
        historico_setor3 = cria_historico_setor(124, '2012-07-10', 11.0, 'Umidade da Terra')
        #historico_setor2 = cria_historico_setor(setor1, make_aware('2012-05-10', 'America/Sao_Paulo Brazil/East'), '2', '12', '17')
        
        def cria_contato_fazenda(fazenda, nome_contato, descricao_contato, telefone):
            contato_fazenda = Contato(fazenda=fazenda, nome_contato=nome_contato, descricao_contato=descricao_contato, telefone=telefone)
            contato_fazenda.save()
            return contato_fazenda
        
        contato_fazenda1 = cria_contato_fazenda(fazenda1, 'Jose', 'Responsável pelo arroz','11-9999-9999')
        contato_fazenda2 = cria_contato_fazenda(fazenda1, 'Joao', 'Responsável pelo milho', '11-9999-9999')
        contato_fazenda3 = cria_contato_fazenda(fazenda2, 'Joao2', 'Responsável pelo café', '11-9999-9999')
        