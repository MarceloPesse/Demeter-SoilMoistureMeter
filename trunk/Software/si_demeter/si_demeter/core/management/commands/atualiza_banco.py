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
        
        usuario1 = cria_usuario('jhonston', 'jhonston')
        usuario2 = cria_usuario('bonfa', 'bonfa')
        usuario3 = cria_usuario('pesse', 'pesse')
        usuario4 = cria_usuario('camilo', 'camilo')
        usuario5 = cria_usuario('kleber', 'kleber')
        usuario6 = cria_usuario('takeo', 'takeo')
        usuario7 = cria_usuario('ramona', 'ramona')
        usuario8 = cria_usuario('zuffo', 'zuffo')
        usuario9 = cria_usuario('carlos', 'carlos')
        usuario10 = cria_usuario('antonio', 'antonio')
        #usuario = User.objects.create_user(username='tones', password='tonesp', email='jhonston@gmail.com')
        admin1 = cria_usuario_admin('admin', 'admin')
        admin2 = cria_usuario_admin('Mezenga', 'mezenga')
        admin3 = cria_usuario_admin('Berdinazzi', 'berdinazzi')
        
        def cria_fazenda(usuario, nome_fazenda, descricao_fazenda, endereco):
            fazenda = Fazenda(usuario=usuario, nome_fazenda=nome_fazenda, descricao_fazenda=descricao_fazenda, endereco=endereco)
            fazenda.save()
            return fazenda
        
        fazenda1 = cria_fazenda(usuario1, 'Fazenda Fruto da Terra', 'Fazenda criada em 1965, terra vermelha e muito sol.', 'av. professor melo moraes 1235 - butanta - sao paulo')
        fazenda2 = cria_fazenda(usuario1, 'Fazenda Amanhecer', 'Fazenda criada em 1965, terra vermelha e muito sol.', 'av. professor melo moraes 1235 - butanta - sao paulo')
        fazenda3 = cria_fazenda(usuario2, 'Fazenda Vegetais', 'Fazenda de produtos organicos.', 'Av. Pedro Alvares Cabral 1986 - Caravelas - Lindoia - SP')
        fazenda4 = cria_fazenda(usuario2, 'Fazenda Natural', 'Fazenda litoranea com muito sol.', 'av. Presidente Wilson 1990 - Sao Vicente - SP')
        fazenda5 = cria_fazenda(usuario3, 'Fazenda Anoitecer', 'Fazenda de cogumelos exoticos.', 'av. das Nacoes Unidas 1363 - Sao Paulo - SP')
        fazenda6 = cria_fazenda(usuario3, 'Fazenda Raposa Izuna', 'Fazenda muito umida, excelente para cultivo de arroz.', 'av. Uchiha 1991 - Monte Izuna - Japao')
        fazenda7 = cria_fazenda(usuario4, 'Fazenda Dinamarca', 'Fazenda de temperaturas glaciais.', 'Viborgvej 1235 - Randers - Dinamarca')
        fazenda8 = cria_fazenda(usuario5, 'Fazenda Antenas', 'Fazenda com muitos sinais.', 'Rua Roberto Landell de Moura 1901 - butanta - sao paulo')
        fazenda9 = cria_fazenda(usuario6, 'Fazenda PSI', 'Fazenda high tech.', 'av. professor Luiz de Queiros Orsini 2012 - butanta - sao paulo')
        fazenda10 = cria_fazenda(usuario7, 'Fazenda Eletrica', 'Fazenda de Alta Tensao.', 'av. Alessandro Volta 1745 - butanta - sao paulo')
        fazenda11 = cria_fazenda(usuario8, 'Fazenda Poli', 'Fazenda com muitos trabalhadores.', 'av. Ramos de Azevedo 1851 - butanta - sao paulo')
        
        def cria_setor(fazenda, regiao_setor, cultura_setor, descricao_setor, id_modulo, valor_referencia, latitude, longitude):
            setor = Setor(fazenda=fazenda, regiao_setor=regiao_setor, cultura_setor=cultura_setor, descricao_setor=descricao_setor, id_modulo=id_modulo,
                          valor_referencia=valor_referencia, latitude=latitude, longitude=longitude)
            setor.save()
            return setor
        
        setor1 = cria_setor(fazenda1, 'Norte da Fazenda', 'Arroz', 'Arroz de exportação', 123, 9.0, -23.559, -46.722)
        setor2 = cria_setor(fazenda1, 'Sul da Fazenda', 'Milho', 'Milho de exportação', 124, 12.0, -23.553, -46.728)
        setor3 = cria_setor(fazenda1, 'Leste da Fazenda', 'Café', 'Café de exportação', 125, 19.0, -23.557, -46.724)
        setor4 = cria_setor(fazenda1, 'Oeste da Fazenda', 'Tomate', 'Tomate de exportação', 127, 18.0, -23.551, -46.720)
        setor5 = cria_setor(fazenda2, 'Norte da Fazenda', 'Soja', 'Soja de exportação', 128, 11.0, -23.559, -46.722)
        setor6 = cria_setor(fazenda2, 'Sul da Fazenda', 'Quinoa', 'Quinoa de exportação', 129, 12.0, -23.553, -46.728)
        setor7 = cria_setor(fazenda3, 'Leste da Fazenda', 'Cana', 'Cana de exportação', 130, 20.0, -23.557299699999774, -46.72210693359375)
        setor8 = cria_setor(fazenda4, 'Oeste da Fazenda', 'Cacao', 'Cacao de exportação', 131, 17.0, -23.557299699999774, -46.72210693359375)
        setor9 = cria_setor(fazenda5, 'Norte da Fazenda', 'Shitake', 'Shitake de exportação', 132, 19.0, -23.553, -46.728)
        setor10 = cria_setor(fazenda5, 'Sul da Fazenda', 'Shimeji', 'Shimeji de exportação', 133, 19.0, -23.557299699999774, -46.72210693359375)
        setor1 = cria_setor(fazenda6, 'Leste da Fazenda', 'Arroz', 'Arroz de exportação', 126, 20.0, -23.557299699999774, -46.72210693359375)
        setor11 = cria_setor(fazenda6, 'Oeste da Fazenda', 'Alface', 'Alface de exportação', 134, 18.0, -23.553, -46.728)
        
        def cria_historico_setor(id_modulo, id_sensor, data_medida, valor_medida, tipo_sensor):
            historico_setor = HistoricoSetor(id_modulo=id_modulo, id_sensor=id_sensor, data_medida=data_medida, valor_medida=valor_medida, tipo_sensor=tipo_sensor)
            historico_setor.save()
            return historico_setor
        
        historico_setor1 = cria_historico_setor(123, '1', '2012-05-10', 10.0, '3')
        historico_setor2 = cria_historico_setor(123, '1', '2012-06-10', 15.0, '3')
        historico_setor2 = cria_historico_setor(123, '1', '2012-07-10', 20.0, '3')
        historico_setor2 = cria_historico_setor(123, '1', '2012-08-10', 15.0, '3')
        historico_setor2 = cria_historico_setor(123, '1', '2012-09-10', 10.0, '3')
        historico_setor3 = cria_historico_setor(124, '1', '2012-06-10', 10.0, '3')
        historico_setor3 = cria_historico_setor(124, '1', '2012-07-10', 11.0, '3')
        historico_setor4 = cria_historico_setor(125, '1', '2012-05-10', 09.0, '3')
        historico_setor4 = cria_historico_setor(125, '1', '2012-10-10', 05.0, '3')
        historico_setor4 = cria_historico_setor(126, '1', '2012-06-10', 22.0, '3')
        historico_setor5 = cria_historico_setor(126, '1', '2012-11-10', 41.0, '3')
        historico_setor5 = cria_historico_setor(127, '1', '2011-12-10', 10.0, '3')
        historico_setor6 = cria_historico_setor(127, '1', '2012-01-10', 13.0, '3')
        historico_setor6 = cria_historico_setor(128, '1', '2012-11-10', 30.0, '3')
        historico_setor7 = cria_historico_setor(128, '1', '2012-12-01', 25.0, '3')
        historico_setor7 = cria_historico_setor(129, '1', '2012-07-10', 15.0, '3')
        #historico_setor2 = cria_historico_setor(setor1, make_aware('2012-05-10', 'America/Sao_Paulo Brazil/East'), '2', '12', '17')
        
        def cria_contato_usuario(usuario, nome_contato, descricao_contato, telefone):
            contato_fazenda = Contato(usuario=usuario, nome_contato=nome_contato, descricao_contato=descricao_contato, telefone=telefone)
            contato_fazenda.save()
            return contato_fazenda
        
        contato_usuario1 = cria_contato_usuario(usuario1, 'Jose', 'Responsável pelo arroz','11-1111-1111')
        contato_usuario2 = cria_contato_usuario(usuario1, 'Joao', 'Responsável pelo milho', '11-1111-2222')
        contato_usuario3 = cria_contato_usuario(usuario2, 'Andre', 'Responsável pelo tomate', '11-2222-1111')
        contato_usuario4 = cria_contato_usuario(usuario3, 'Rafael', 'Responsável pela soja', '11-3333-1111')
        contato_usuario5 = cria_contato_usuario(usuario3, 'Roberval', 'Responsável pela quinoa', '11-3333-2222')
        contato_usuario6 = cria_contato_usuario(usuario3, 'Pedro', 'Responsável pelo espinafre', '11-3333-3333')
        contato_usuario7 = cria_contato_usuario(usuario4, 'Luis', 'Responsável pela cana', '13-4444-1111')
        contato_usuario8 = cria_contato_usuario(usuario4, 'Antonio', 'Responsável pelo cacao', '13-4444-2222')
        contato_usuario9 = cria_contato_usuario(usuario5, 'Mario', 'Responsável pelo shitake', '11-5555-1111')
        contato_usuario10 = cria_contato_usuario(usuario5, 'Luigi', 'Responsável pelo shimeji', '11-5555-2222')
        contato_usuario10 = cria_contato_usuario(usuario6, 'Akira', 'Responsável pelo arroz', '11-5555-2222')
        contato_usuario11 = cria_contato_usuario(usuario6, 'Henrique', 'Responsável pelo alface', '11-5555-2222')
        