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
            return usuario
            
        def cria_usuario_admin(username, password):
            usuario = cria_usuario(username, password)
            usuario.is_staff = True
            usuario.is_active = True
            usuario.is_superuser = True
            usuario.save()
            return usuario
        
        usuario1 = cria_usuario('tones', 'tones')
        admin1 = cria_usuario_admin('admin', 'admin')
        
        def cria_fazenda(usuario, nome_fazenda, descricao_fazenda, endereco, cidade, estado, data_visualizacao, data_modificacao):
            fazenda = Fazenda(usuario=usuario, nome_fazenda=nome_fazenda, descricao_fazenda=descricao_fazenda,
                              endereco=endereco, cidade=cidade, estado=estado, data_visualizacao=data_visualizacao, data_modificacao=data_modificacao)
            fazenda.save()
            return fazenda
        
        fazenda1 = cria_fazenda(usuario1, 'Fazenda Fruto da Terra', 'Fazenda criada em 1965, terra vermelha e muito sol.', 'Rod. Marechal do Norte', 'Boituva', 'SP', '2012-05-10', '2012-06-10')
        fazenda2 = cria_fazenda(usuario1, 'Fazenda Amanhecer', 'Fazenda criada em 1965, terra vermelha e muito sol.', 'Rod. Marechal do Norte', 'Boituva', 'SP', '2012-05-10', '2012-06-10')
        
        def cria_setor(fazenda, numero_setor, cultura_setor, descricao_setor):
            setor = Setor(fazenda=fazenda, numero_setor=numero_setor, cultura_setor=cultura_setor, descricao_setor=descricao_setor)
            setor.save()
            return setor
        
        setor1 = cria_setor(fazenda1, '1', 'Arroz', 'Norte da Fazenda')
        setor2 = cria_setor(fazenda1, '2', 'Milho', 'Sul da Fazenda')
        setor3 = cria_setor(fazenda2, '1', 'Café', 'Norte da Fazenda')
        
        def cria_historico_setor(setor, data_medida, id_modulo, medida1, medida2, medida3, medida4):
            historico_setor = HistoricoSetor(setor=setor, data_medida=data_medida, id_modulo=id_modulo, medida1=medida1,  medida2=medida2,  medida3=medida3,  medida4=medida4)
            historico_setor.save()
            return historico_setor
        
        historico_setor1 = cria_historico_setor(setor1, '2012-05-10', 1.0, 10.0, 15.0, 12.0, 17.0)
        historico_setor2 = cria_historico_setor(setor1, '2012-06-10', 1.0, 11.0, 16.0, 13.0, 18.0)
        historico_setor3 = cria_historico_setor(setor1, '2012-07-10', 1.0, 12.0, 17.0, 14.0, 19.0)
        #historico_setor2 = cria_historico_setor(setor1, make_aware('2012-05-10', 'America/Sao_Paulo Brazil/East'), '2', '12', '17')
        
        def cria_contato_fazenda(fazenda, nome_contato, descricao_contato, telefone):
            contato_fazenda = Contato(fazenda=fazenda, nome_contato=nome_contato, descricao_contato=descricao_contato, telefone=telefone)
            contato_fazenda.save()
            return contato_fazenda
        
        contato_fazenda1 = cria_contato_fazenda(fazenda1, 'Jose', 'Responsável pelo arroz','11-9999-9999')
        contato_fazenda2 = cria_contato_fazenda(fazenda1, 'Joao', 'Responsável pelo milho', '11-9999-9999')
        contato_fazenda3 = cria_contato_fazenda(fazenda2, 'Joao2', 'Responsável pelo café', '11-9999-9999')
        