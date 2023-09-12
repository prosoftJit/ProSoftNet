using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.ComponentModel;
using System.Web.Mvc;
using System.IO;
using System.Linq.Expressions;
using System.Data.Entity;
//using System.Data.Entity.Validation;
using System.Web;
using System.Web.Helpers;
using System.Reflection;
using System.ComponentModel.DataAnnotations;
//using System.Data.Entity.Infrastructure;
using System.Collections;
using System.Data.SqlTypes;
using System.Security.Cryptography.X509Certificates;
//using System.Web.UI.WebControls;
//using System.Web.WebPages.Html;
using System.Reflection.Emit;
//using System.Web.Mvc.Html;
//using System.Runtime.Remoting.Messaging;
using System.Net.NetworkInformation;
using System.Runtime.CompilerServices;
using static System.Collections.Specialized.BitVector32;
using System.Security.Policy;
//using System.Web.Routing;
using System.Dynamic;
using System.Xml.Linq;
using System.Xml.Serialization;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace System
{
    public enum SiteMapLink
    {
        Home,
        ACamara,
        RegimentoInterno,
        LOM,
        EstruturaOrganizacional,
        Parametros,
        MapaDoSite,
        Compras,
        Credor_Rubrica,
        Empenho,
        Cancelamento,
        Rubricas,
        Credores,
        FAQ,
        Sessoes,
        Materias,
        Materia,
        Vereadores,
        Noticias,
        OMunicipio,
        Historia,
        Turismo,
        Simbolos,
        ComoChegar,
        Funcionarios,
        Funcionario,
        ComissoesPermanentes,
        EleicoesDaMesa,
        QuadroDeCargosEFuncoes,
        TabelaDeVencimentos,
        Contatos,
        AtividadeLegislativa,
        Pauta,
        MateriasEmTramitacao,
        MateriasLegislativas,
        MenuTransparencia,
        MenuItemTransparencia,
        PortalDaTransparencia,
        ComprasELicitacoes,
        Ouvidoria,
        LicitaconCidadao,
        Diarias,
        BalancetesEDemsContabeis,
        Comunicacao,
        Publicacoes,
        RelatoriosDeGestao,
        RedesSociais,
        SIC,
        ProtecaoDeDados,
        DeixeMensagem
    }

    public class MySiteMap
    {
        public List<SiteMapMenu> Menus = new List<SiteMapMenu>();

        public SiteMapItem Home = new SiteMapItem
        {
            Tipo = SiteMapLink.Home,
            Description = "Home",
            Url = "/Home/Index"
        };

        public static MySiteMap instance = new MySiteMap();
        public SiteMapPlace Find(string description)
        {
            foreach (SiteMapPlace smm in Menus)
            {
                SiteMapPlace smp = smm.Descendants(k => k.Childs).FirstOrDefault(k => k.Description == description);
                if (smp != null)
                    return smp;
            }
            return null;
        }
        public SiteMapPlace Find(SiteMapLink tipo)
        {
            foreach (SiteMapPlace smm in Menus)
            {
                SiteMapPlace smp = smm.Descendants(k => k.Childs).FirstOrDefault(k => k.Tipo == tipo);
                if (smp != null)
                    return smp;
            }
            return null;
        }
        public MySiteMap()
        {
            Menus.Add(new SiteMapMenu
            {
                Tipo = SiteMapLink.OMunicipio,
                Description = "O Município",
                Childs = new SiteMapItem[] {
                    new SiteMapItem
                    {
                        Tipo = SiteMapLink.Historia,
                        Description = "História",
                        Url = "/Home/Historia",
                    },
                    new SiteMapItem{
                        Tipo = SiteMapLink.Turismo,
                        Description = "Turismo",
                        Url = "/Home/Turismo"
                    },
                    new SiteMapItem{
                        Tipo = SiteMapLink.Simbolos,
                        Description = "Símbolos",
                        Url = "/Home/Simbolos"
                    },
                    new SiteMapItem{
                        Tipo = SiteMapLink.ComoChegar,
                        Description = "Como Chegar",
                        Url = "/Home/ComoChegar"
                    }
                }
            });

            Menus.Add(new SiteMapMenu
            {
                Tipo = SiteMapLink.ACamara,
                Description = "A Câmara",
                Childs = new SiteMapItem[] {
                    new SiteMapItem{
                        Tipo = SiteMapLink.EstruturaOrganizacional,
                        Description = "Estrutura Organizacional",
                        Url = "/Home/Estrutura_organizacional"
                    },
                    new SiteMapItem{
                        Tipo = SiteMapLink.Funcionarios,
                        Description = "Funcionários",
                        Url = "/Home/Funcionarios",
                        Childs = new SiteMapItem[] {
                            new SiteMapItem {
                                Tipo = SiteMapLink.Funcionario,
                                Description = "Funcionario",
                                Url = "/Home/Funcionario?idFuncionario={0}"
                            }
                        }
                    },
                    new SiteMapItem{
                        Tipo = SiteMapLink.ComissoesPermanentes,
                        Description = "Comissões Permanentes",
                        Url = ""
                    },
                    new SiteMapItem{
                        Tipo = SiteMapLink.EleicoesDaMesa,
                        Description = "Eleições da Mesa Diretora",
                        Url = ""
                    },
                    new SiteMapItem{
                        Tipo = SiteMapLink.RegimentoInterno,
                        Description = "Regimento Interno",
                        Url = ""
                    },
                    new SiteMapItem{
                        Tipo = SiteMapLink.LOM,
                        Description = "Lei Orgânica Municipal",
                        Url = ""
                    },
                    new SiteMapItem{
                        Tipo = SiteMapLink.QuadroDeCargosEFuncoes,
                        Description = "Quadro de Cargos e Funções",
                        Url = ""
                    },
                    new SiteMapItem{
                        Tipo = SiteMapLink.TabelaDeVencimentos,
                        Description = "Tabela de Vencimentos",
                        Url = ""
                    },
                    new SiteMapItem{
                        Tipo = SiteMapLink.Parametros,
                        Description = "Parâmetros",
                        Url = "/Home/EditarParametros",
                        LoginRequired = true
                    },
                    new SiteMapItem{
                        Tipo = SiteMapLink.MapaDoSite,
                        Description = "Mapa do Site",
                        Url = "/Home/SiteMap"
                    }
                }
            });

            //Menus.Add(new SiteMapMenu(SiteMapLink.Compras, "Compras",
            //        new SiteMapItem(SiteMapLink.Credor_Rubrica, "Credor/Rubrica",
            //        "", false, new SiteMapItem[] {
            //            new SiteMapItem(SiteMapLink.Empenho, "Empenho", "", false, new SiteMapItem[] {
            //                new SiteMapItem(SiteMapLink.Cancelamento, "Cancelamento", "")
            //            })
            //        }),
            //        new SiteMapItem(SiteMapLink.Rubricas, "Rubricas", ""),
            //        new SiteMapItem(SiteMapLink.Credores, "Credores", "")
            //    }),

            Menus.Add(
                new SiteMapMenu
                {
                    Tipo = SiteMapLink.Vereadores,
                    Description = "Vereadores",
                    Childs = new SiteMapItem[] {
                    new SiteMapItem
                    {
                        Tipo = SiteMapLink.Vereadores,
                        Description = "Vereadores",
                        Url = ""
                    },
                    new SiteMapItem
                    {
                        Tipo = SiteMapLink.Contatos,
                        Description = "Contatos",
                        Url = ""
                    }
                }
                });

            Menus.Add(
                new SiteMapMenu
                {
                    Tipo = SiteMapLink.AtividadeLegislativa,
                    Description = "Atividade Legislativa",
                    Childs = new SiteMapItem[] {
                        new SiteMapItem{
                            Tipo = SiteMapLink.Pauta,
                            Description = "Pauta da próxima Sessão",
                            Url = ""
                        },
                        new SiteMapItem{
                            Tipo = SiteMapLink.MateriasEmTramitacao,
                            Description = "Matérias em tramitação",
                            Url = ""
                        },
                        new SiteMapItem{
                            Tipo = SiteMapLink.Sessoes,
                            Description = "Sessões",
                            Url = "/Ata/Index"
                        },
                        new SiteMapItem{
                            Tipo = SiteMapLink.MateriasLegislativas,
                            Description = "Matérias Legislativas",
                            Url = "/Materia/Index",
                            Childs = new SiteMapPlace[]
                            {
                                new SiteMapPlace
                                {
                                    Tipo = SiteMapLink.Materia,
                                    Description = "Matéria Legislativa",
                                    Url = ""
                                }
                            }
                        }
                    }
                });

            Menus.Add(
                new SiteMapMenu
                {
                    Tipo = SiteMapLink.MenuTransparencia,
                    Description = "Transparência",
                    Childs = new SiteMapItem[] {
                        new SiteMapItem{
                            Tipo = SiteMapLink.MenuItemTransparencia,
                            Description = "Transparência",
                            Url = "/Transparencia/Index"
                        },
                        new SiteMapItem{
                            Tipo = SiteMapLink.PortalDaTransparencia,
                            Description = "Portal da Transparência Municipal",
                            Url = ""
                        },
                        new SiteMapItem{
                            Tipo = SiteMapLink.ComprasELicitacoes,
                            Description = "Compras e Licitações",
                            Url = ""
                        },
                        new SiteMapItem{
                            Tipo = SiteMapLink.Ouvidoria,
                            Description = "Ouvidoria",
                            Url = ""
                        },
                        new SiteMapItem{
                            Tipo = SiteMapLink.LicitaconCidadao,
                            Description = "Licitacon Cidadão",
                            Url = ""
                        },
                        new SiteMapItem{
                            Tipo = SiteMapLink.Diarias,
                            Description = "Diárias",
                            Url = ""
                        },
                        new SiteMapItem{
                            Tipo = SiteMapLink.BalancetesEDemsContabeis,
                            Description = "Balancetes e Demonstrativos Contábeis",
                            Url = ""
                        }
                     }
                });

            Menus.Add(new SiteMapMenu
            {
                Tipo = SiteMapLink.Comunicacao,
                Description = "Comunicação",
                Childs = new SiteMapItem[] {
                new SiteMapItem{
                    Tipo = SiteMapLink.Noticias,
                    Description = "Notícias",
                    Url = ""
                },
                new SiteMapItem{
                    Tipo = SiteMapLink.Publicacoes,
                    Description = "Publicações",
                    Url = ""
                },
                new SiteMapItem{
                    Tipo = SiteMapLink.RelatoriosDeGestao,
                    Description = "Relatórios de Gestão",
                    Url = ""
                },
                new SiteMapItem{
                    Tipo = SiteMapLink.RedesSociais,
                    Description = "Redes Sociais",
                    Url = ""
                },
                new SiteMapItem{
                    Tipo = SiteMapLink.SIC,
                    Description = "Serviço de Informações ao Cidadão - SIc",
                    Url = ""
                },
                new SiteMapItem{
                    Tipo = SiteMapLink.ProtecaoDeDados,
                    Description = "Proteção de dados",
                    Url = ""
                },
                new SiteMapItem{
                    Tipo = SiteMapLink.FAQ,
                    Description = "Perguntas Frequentes",
                    Url = "/FAQ/Index"
                },
                new SiteMapItem{
                    Tipo = SiteMapLink.DeixeMensagem,
                    Description = "Deixe uma mensagem",
                    Url = ""
                }
            }
            });
        }
    };

    public class SiteMapPlace
    {
        public SiteMapLink Tipo;
        public string Description;
        SiteMapPlace[] _childs;
        public string Url = "";
        public SiteMapPlace[] Childs
        {
            get { return _childs; }
            set
            {
                foreach (SiteMapPlace smp in value)
                    smp.Parent = this;
                _childs = value;
            }
        }
        public SiteMapPlace Parent;
        public override string ToString()
        {
            return Description;
        }
        public SiteMapPlace[] Path
        {
            get
            {
                return this.Parents(k => k.Parent).Prepend(MySiteMap.instance.Home).ToArray();
            }
        }
    }

    public class SiteMapMenu : SiteMapPlace
    {
    }

    public class SiteMapItem : SiteMapPlace
    {
        public bool LoginRequired = false;
    }

    /// <summary>
    /// Uma estrutura do tipo tree que pode ser escrita em formato json, com as propriedades
    /// string Nome: o nome do node
    /// Node[] Children: uma array de Node que representa os filhos
    /// "{Name:'Chapas', Children: [{Name: 'Candidatos'}, {Name:'VotosFavoraveis'}]}");
    /// A decodificação se dá com Node n = Node.Decode(string)
    /// </summary>
    public class Node
    {
        public static Node Decode(string value)
        {
            return Json.Decode<Node>(value);
        }

        public Node() { } // used for deserializing

        public Node(string name, Node parent) // used everywhere else in your code
        {
            Name = name;
            Parent = parent;
        }

        public string Name { get; set; }

        private Node Parent { get; set; }

        public Node GetParent()
        {
            return Parent;
        }

        public Node[] Children
        {
            get
            {
                return ChildrenDict.Values.ToArray();
            }

            set
            {
                ChildrenDict.Clear();
                if (value == null || value.Length <= 0) return;
                foreach (Node child in value)
                    Add(child);
            }
        }

        // One could use a typed OrderedDictionary here, since Json lists guarantee the order of the children:
        private Dictionary<string, Node> ChildrenDict { get; } = new Dictionary<string, Node>();

        public Node Add(Node child)
        {
            ChildrenDict.Add(child.Name, child);
            child.Parent = this;
            return child;
        }

        public Node Get(string name)
        {
            return ChildrenDict[name];
        }

        public bool Remove(string name)
        {
            return ChildrenDict.Remove(name);
        }

        public override string ToString()
        {
            return Name;
        }
    }

    public class GeneroAttribute : Attribute
    {
        public GeneroAttribute(string singular, string plural)
        {
            this.Singular = singular;
            this.Plural = plural;
        }
        public string Singular { get; set; }
        public string Plural { get; set; }
        public string Genero(bool plural)
        {
            return plural ? Plural : Singular;
        }
    }

    public static class SystemExtensions
    {
        public enum MimeTypes
        {
            [Description("application/postscript")]
            ai,
            [Description("audio/x-aiff")]
            aif,
            [Description("audio/x-aiff")]
            aifc,
            [Description("audio/x-aiff")]
            aiff,
            [Description("text/plain")]
            asc,
            [Description("application/atom+xml")]
            atom,
            [Description("audio/basic")]
            au,
            [Description("video/x-msvideo")]
            avi,
            [Description("application/x-bcpio")]
            bcpio,
            [Description("application/octet-stream")]
            bin,
            [Description("image/bmp")]
            bmp,
            [Description("application/x-netcdf")]
            cdf,
            [Description("image/cgm")]
            cgm,
            [Description("application/octet-stream")]
            @class,
            [Description("application/x-cpio")]
            cpio,
            [Description("application/mac-compactpro")]
            cpt,
            [Description("application/x-csh")]
            csh,
            [Description("text/css")]
            css,
            [Description("application/x-director")]
            dcr,
            [Description("video/x-dv")]
            dif,
            [Description("application/x-director")]
            dir,
            [Description("image/vnd.djvu")]
            djv,
            [Description("image/vnd.djvu")]
            djvu,
            [Description("application/octet-stream")]
            dll,
            [Description("application/octet-stream")]
            dmg,
            [Description("application/octet-stream")]
            dms,
            [Description("application/msword")]
            doc,
            [Description("application/xml-dtd")]
            dtd,
            [Description("video/x-dv")]
            dv,
            [Description("application/x-dvi")]
            dvi,
            [Description("application/x-director")]
            dxr,
            [Description("application/postscript")]
            eps,
            [Description("text/x-setext")]
            etx,
            [Description("application/octet-stream")]
            exe,
            [Description("application/andrew-inset")]
            ez,
            [Description("image/gif")]
            gif,
            [Description("application/srgs")]
            gram,
            [Description("application/srgs+xml")]
            grxml,
            [Description("application/x-gtar")]
            gtar,
            [Description("application/x-hdf")]
            hdf,
            [Description("application/mac-binhex40")]
            hqx,
            [Description("text/html")]
            htm,
            [Description("text/html")]
            html,
            [Description("x-conference/x-cooltalk")]
            ice,
            [Description("image/x-icon")]
            ico,
            [Description("text/calendar")]
            ics,
            [Description("image/ief")]
            ief,
            [Description("text/calendar")]
            ifb,
            [Description("model/iges")]
            iges,
            [Description("model/iges")]
            igs,
            [Description("application/x-java-jnlp-file")]
            jnlp,
            [Description("image/jp2")]
            jp2,
            [Description("image/jpeg")]
            jpe,
            [Description("image/jpeg")]
            jpeg,
            [Description("image/jpeg")]
            jpg,
            [Description("application/x-javascript")]
            js,
            [Description("audio/midi")]
            kar,
            [Description("application/x-latex")]
            latex,
            [Description("application/octet-stream")]
            lha,
            [Description("application/octet-stream")]
            lzh,
            [Description("audio/x-mpegurl")]
            m3u,
            [Description("audio/mp4a-latm")]
            m4a,
            [Description("audio/mp4a-latm")]
            m4b,
            [Description("audio/mp4a-latm")]
            m4p,
            [Description("video/vnd.mpegurl")]
            m4u,
            [Description("video/x-m4v")]
            m4v,
            [Description("image/x-macpaint")]
            mac,
            [Description("application/x-troff-man")]
            man,
            [Description("application/mathml+xml")]
            mathml,
            [Description("application/x-troff-me")]
            me,
            [Description("model/mesh")]
            mesh,
            [Description("audio/midi")]
            mid,
            [Description("audio/midi")]
            midi,
            [Description("application/vnd.mif")]
            mif,
            [Description("video/quicktime")]
            mov,
            [Description("video/x-sgi-movie")]
            movie,
            [Description("audio/mpeg")]
            mp2,
            [Description("audio/mpeg")]
            mp3,
            [Description("video/mp4")]
            mp4,
            [Description("video/mpeg")]
            mpe,
            [Description("video/mpeg")]
            mpeg,
            [Description("video/mpeg")]
            mpg,
            [Description("audio/mpeg")]
            mpga,
            [Description("application/x-troff-ms")]
            ms,
            [Description("model/mesh")]
            msh,
            [Description("video/vnd.mpegurl")]
            mxu,
            [Description("application/x-netcdf")]
            nc,
            [Description("application/oda")]
            oda,
            [Description("application/ogg")]
            ogg,
            [Description("image/x-portable-bitmap")]
            pbm,
            [Description("image/pict")]
            pct,
            [Description("chemical/x-pdb")]
            pdb,
            [Description("application/pdf")]
            pdf,
            [Description("image/x-portable-graymap")]
            pgm,
            [Description("application/x-chess-pgn")]
            pgn,
            [Description("image/pict")]
            pic,
            [Description("image/pict")]
            pict,
            [Description("image/png")]
            png,
            [Description("image/x-portable-anymap")]
            pnm,
            [Description("image/x-macpaint")]
            pnt,
            [Description("image/x-macpaint")]
            pntg,
            [Description("image/x-portable-pixmap")]
            ppm,
            [Description("application/vnd.ms-powerpoint")]
            ppt,
            [Description("application/postscript")]
            ps,
            [Description("video/quicktime")]
            qt,
            [Description("image/x-quicktime")]
            qti,
            [Description("image/x-quicktime")]
            qtif,
            [Description("audio/x-pn-realaudio")]
            ra,
            [Description("audio/x-pn-realaudio")]
            ram,
            [Description("image/x-cmu-raster")]
            ras,
            [Description("application/rdf+xml")]
            rdf,
            [Description("image/x-rgb")]
            rgb,
            [Description("application/vnd.rn-realmedia")]
            rm,
            [Description("application/x-troff")]
            roff,
            [Description("text/rtf")]
            rtf,
            [Description("text/richtext")]
            rtx,
            [Description("text/sgml")]
            sgm,
            [Description("text/sgml")]
            sgml,
            [Description("application/x-sh")]
            sh,
            [Description("application/x-shar")]
            shar,
            [Description("model/mesh")]
            silo,
            [Description("application/x-stuffit")]
            sit,
            [Description("application/x-koan")]
            skd,
            [Description("application/x-koan")]
            skm,
            [Description("application/x-koan")]
            skp,
            [Description("application/x-koan")]
            skt,
            [Description("application/smil")]
            smi,
            [Description("application/smil")]
            smil,
            [Description("audio/basic")]
            snd,
            [Description("application/octet-stream")]
            so,
            [Description("application/x-futuresplash")]
            spl,
            [Description("application/x-wais-source")]
            src,
            [Description("application/x-sv4cpio")]
            sv4cpio,
            [Description("application/x-sv4crc")]
            sv4crc,
            [Description("image/svg+xml")]
            svg,
            [Description("application/x-shockwave-flash")]
            swf,
            [Description("application/x-troff")]
            t,
            [Description("application/x-tar")]
            tar,
            [Description("application/x-tcl")]
            tcl,
            [Description("application/x-tex")]
            tex,
            [Description("application/x-texinfo")]
            texi,
            [Description("application/x-texinfo")]
            texinfo,
            [Description("image/tiff")]
            tif,
            [Description("image/tiff")]
            tiff,
            [Description("application/x-troff")]
            tr,
            [Description("text/tab-separated-values")]
            tsv,
            [Description("text/plain")]
            txt,
            [Description("application/x-ustar")]
            ustar,
            [Description("application/x-cdlink")]
            vcd,
            [Description("model/vrml")]
            vrml,
            [Description("application/voicexml+xml")]
            vxml,
            [Description("audio/x-wav")]
            wav,
            [Description("image/vnd.wap.wbmp")]
            wbmp,
            [Description("application/vnd.wap.wbxml")]
            wbmxl,
            [Description("text/vnd.wap.wml")]
            wml,
            [Description("application/vnd.wap.wmlc")]
            wmlc,
            [Description("text/vnd.wap.wmlscript")]
            wmls,
            [Description("application/vnd.wap.wmlscriptc")]
            wmlsc,
            [Description("model/vrml")]
            wrl,
            [Description("image/x-xbitmap")]
            xbm,
            [Description("application/xhtml+xml")]
            xht,
            [Description("application/xhtml+xml")]
            xhtml,
            [Description("application/vnd.ms-excel")]
            xls,
            [Description("application/xml")]
            xml,
            [Description("image/x-xpixmap")]
            xpm,
            [Description("application/xml")]
            xsl,
            [Description("application/xslt+xml")]
            xslt,
            [Description("application/vnd.mozilla.xul+xml")]
            xul,
            [Description("image/x-xwindowdump")]
            xwd,
            [Description("chemical/x-xyz")]
            xyz,
            [Description("application/zip")]
            zip
        }

        public static string GetMimeType(this string filename)
        {
            string ext = System.IO.Path.GetExtension(filename).Substring(1);
            MimeTypes mt;
            if (Enum.TryParse<MimeTypes>(ext, out mt))
                return mt.GetEnumDescription();
            else
                return null;
        }

        public static string Format(this string str, params object[] pars)
        {
            if (str != null)
                return string.Format(str, pars);
            return string.Empty;
        }

        public static string FormatSQL(this string str, params object[] pars)
        {
            List<string> pars2 = new List<string>();
            if (str != null)
                foreach (object par in pars)
                {
                    if (par == null) pars2.Add("NULL");
                    else if (par is DateTime) pars2.Add("'" + ((DateTime)par).ToString("MM/dd/yyyy") + "'");
                    else if (!(par is string) && par.ToString().Contains(',')) pars2.Add(par.ToString().Replace(',', '.'));
                    else if (par is string || par is bool) pars2.Add("'" + par.ToString() + "'");
                    else pars2.Add(par.ToString());
                }
            return string.Format(str, pars2.ToArray());
            return string.Empty;
        }

        public static string GetEnumDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fi.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
            {
                DisplayAttribute[] dattr =
                    (DisplayAttribute[])fi.GetCustomAttributes(
                    typeof(DisplayAttribute),
                    false);

                if (dattr != null && dattr.Length > 0)
                    return dattr[0].Name;
            }
            return value.ToString();
        }

        public static T Attribute<T>(this Type type, string propertyName) where T : Attribute //Hint: Change the method signature and input paramter to use the type parameter T
        {
            PropertyInfo pi = type.GetProperty(propertyName);
            if (pi != null)
                return pi.GetCustomAttributes<T>().FirstOrDefault();
            else
                return null;
        }

        // get description from enum
        public static T Attribute<T>(this Type type) where T : Attribute //Hint: Change the method signature and input paramter to use the type parameter T
        {
            var attrs = type.GetCustomAttributes(typeof(T), true);
            T attr = attrs.FirstOrDefault() as T;
            return attr;
        }
        public static T Attribute<T>(this Enum generic) where T : Attribute
        {
            Type genericType = generic.GetType();
            System.Reflection.MemberInfo[] memberInfo = genericType.GetMember(generic.ToString());
            if ((memberInfo != null && memberInfo.Length > 0))
            {
                var _Attribs = memberInfo[0].GetCustomAttributes(typeof(T), false);
                if ((_Attribs != null && _Attribs.Count() > 0))
                {
                    return ((T)_Attribs.ElementAt(0));
                }
            }
            return null;
        }

        /// <summary>
        ///     A generic extension method that aids in reflecting 
        ///     and retrieving any attribute that is applied to an `Enum`.
        /// </summary>
        public static TAttribute GetAttribute<TAttribute>(this Enum enumValue)
                where TAttribute : Attribute
        {
            return enumValue.GetType()
                            .GetMember(enumValue.ToString())
                            .First()
                            .GetCustomAttribute<TAttribute>();
        }
    }

    public static class DateTimeExtensions
    {
        public static string AsShortDateString(this DateTime? dateTime)
        {
            if (dateTime == null)
                return null;
            else
                return ((DateTime)dateTime).ToShortDateString();
        }
        public static string AsYMDString(this DateTime? dateTime)
        {
            if (dateTime == null)
                return null;
            else
                return ((DateTime)dateTime).ToString("yyyy-MM-dd");
        }
        public static string AsYMDString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }
        public static string AsString(this DateTime? dateTime, string format = null)
        {
            if (dateTime == null)
                return null;
            else
                if (string.IsNullOrEmpty(format))
                return ((DateTime)dateTime).ToString();
            else
                return ((DateTime)dateTime).ToString(format);
        }
    }
}

namespace System.Data.Entity
{
    public interface IEntityInitialize
    {
        void Initialize(DbContext context);
    }
    public interface IEntityDestroy
    {
        /// <summary>
        /// Chamada quando uma entidade está prestes a ser excluida do bando de dados
        /// </summary>
        /// <param name="context"></param>
        void Destroy(DbContext context);
    }
    public interface IEntityUpdate
    {
        void Update(DbContext context);
    }

    public static class SystemDataEntity
    {
        public static void Remove<T>(this DbSet<T> dataset, long id) where T : class
        {
            T entity = dataset.Find(id);
            dataset.Remove(entity);
        }
        public static void WriteEdmx(this DbContext context, string writePath)
        {
            //https : / / stackoverflow.com/questions/40956330/how-to-generate-class-diagram-from-models-in-ef-core
        }
    }

}

namespace System.Web.Mvc
{
    public static class HtmlPrefixScopeExtensions
    {
        private const string idsToReuseKey = "__htmlPrefixScopeExtensions_IdsToReuse_";

        /*
            @using (Html.BeginCollectionItem("AnswerChoices")) {
                @Html.HiddenFor(m => m.AnswerChoiceId)
                @Html.TextBoxFor(m => m.Name)
            }         
        */
        /// <summary>
        /// Usado para acertar o nome dos controles html quando usados com coleções (nomes indexados)
        /// Suporta múltiplos níveis (nested)
        /// Pode ser usado com ajax, mas a variável ContainerPrefix deve ser passada ao controlador depois
        /// passada de volta ao view através do ViewData 
        /// 
        ///		<button ... data-containerprefix="@ViewData["ContainerPrefix"]" onclick="addCandidato(this, @Model.IdEleicaoChapa)">+ Candidatura</button>
        ///     ajax('/Eleicao/EditCandidato', { containerPrefix: $(btn).data('containerprefix') }, function(ret) ...
        ///     public ActionResult EditCandidato(string containerPrefix) {
        ///         ViewData["ContainerPrefix"] = containerPrefix;
        ///     }
        ///
        ///      @using(Html.BeginCollectionItem("AnswerChoices")) {
        ///         @Html.HiddenFor(m => m.AnswerChoiceId)
        ///         @Html.TextBoxFor(m => m.Name)
        ///      }
        ///
        /// </summary>
        /// <param name="html"></param>
        /// <param name="collectionName"></param>
        /// <returns></returns>
        public static IDisposable BeginCollectionItem(this HtmlHelper html, string collectionName)
        {
            string idx = "";
            return BeginCollectionItem(html, collectionName, out idx);
        }
        public static IDisposable BeginCollectionItem(this HtmlHelper html, string collectionName, out string itemIndex)
        {
            if (html.ViewData["ContainerPrefix"] != null)
            {
                collectionName = string.Concat(html.ViewData["ContainerPrefix"], ".", collectionName);
            }

            var idsToReuse = GetIdsToReuse(html.ViewContext.HttpContext, collectionName);
            //string itemIndex;
            if (idsToReuse.Count > 0)
                itemIndex = idsToReuse.Dequeue();
            else
            {
                //19e7b182-7fa9-4aae-8001-f86e5eb2b089
                string guid = Guid.NewGuid().ToString();
                guid = guid.Split('-').Last();
                itemIndex = guid;
            }

            var htmlFieldPrefix = string.Format("{0}[{1}]", collectionName, itemIndex);

            html.ViewData["ContainerPrefix"] = htmlFieldPrefix;

            // autocomplete="off" is needed to work around a very annoying Chrome behaviour whereby it reuses old values after the user clicks "Back", which causes the xyz.index and xyz[...] values to get out of sync.
            html.ViewContext.Writer.WriteLine(string.Format("<input type=\"hidden\" name=\"{0}.index\" autocomplete=\"off\" value=\"{1}\" />", collectionName, html.Encode(itemIndex)));

            return BeginHtmlFieldPrefixScope(html, htmlFieldPrefix);
        }
        static IDisposable BeginHtmlFieldPrefixScope(this HtmlHelper html, string htmlFieldPrefix)
        {
            return new HtmlFieldPrefixScope(html.ViewData.TemplateInfo, htmlFieldPrefix);
        }
        private static Queue<string> GetIdsToReuse(HttpContext httpContext, string collectionName)
        {
            // We need to use the same sequence of IDs following a server-side validation failure,  
            // otherwise the framework won't render the validation error messages next to each item.
            string key = idsToReuseKey + collectionName;
            var queue = (Queue<string>)httpContext.Items[key];
            if (queue == null)
            {
                httpContext.Items[key] = queue = new Queue<string>();
                var previouslyUsedIds = "";// httpContext.Request.get.Request[collectionName + ".index"];
                throw new NotImplementedException();
                if (!string.IsNullOrEmpty(previouslyUsedIds))
                    foreach (string previouslyUsedId in previouslyUsedIds.Split(','))
                        queue.Enqueue(previouslyUsedId);
            }
            return queue;
        }
        private class HtmlFieldPrefixScope : IDisposable
        {
            private readonly TemplateInfo templateInfo;
            private readonly string previousHtmlFieldPrefix;

            public HtmlFieldPrefixScope(TemplateInfo templateInfo, string htmlFieldPrefix)
            {
                this.templateInfo = templateInfo;

                previousHtmlFieldPrefix = templateInfo.HtmlFieldPrefix;
                templateInfo.HtmlFieldPrefix = htmlFieldPrefix;
            }

            public void Dispose()
            {
                templateInfo.HtmlFieldPrefix = previousHtmlFieldPrefix;
            }
        }
    }
    public class HtmlAttributes : Dictionary<string, object>
    {
        public HtmlAttributes(object source, BindingFlags bindingAttr = BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.Instance)
        {
            Dictionary<string, object> d = source.GetType().GetProperties(bindingAttr).ToDictionary
            (
                propInfo => propInfo.Name,
                propInfo => propInfo.GetValue(source, null)
            );
            foreach (var v in d)
            {
                this.Add(v.Key, v.Value);
            }
        }
        public T ToObject<T>() where T : class, new()
        {
            var someObject = new T();
            var someObjectType = someObject.GetType();

            foreach (var item in this)
            {
                someObjectType
                         .GetProperty(item.Key)
                         .SetValue(someObject, item.Value, null);
            }

            return someObject;
        }
    }
    public static class ExtensoesSWM
    {
        public static Controller CurrentController(this HttpContext context)
        {
            return context.Request.HttpContext.GetRouteData().Values["controller"] as Controller;
        }
        private static object EvaluateExpression(Expression expression)
        {
            var constExpr = expression as ConstantExpression;
            if (constExpr != null)
            {
                return constExpr.Value;
            }

            var lambda = Expression.Lambda(expression);
            var compiled = lambda.Compile();
            return compiled.DynamicInvoke();
        }

        public static string Action<T>(this UrlHelper url, Expression<Func<T, ActionResult>> expression, object routeValues = null) where T : ControllerBase
        {
            string controller = "";

            var methodCallExpression = expression.Body as MethodCallExpression;

            string action = methodCallExpression.Method.Name;

            if (methodCallExpression == null)
            {
                throw new ArgumentException("Not a MethodCallExpression", "expression");
            }

            var methodParameters = methodCallExpression.Method.GetParameters();
            var routeValueArguments = methodCallExpression.Arguments.Select(EvaluateExpression);

            var rawRouteValueDictionary = methodParameters.Select(m => m.Name)
                                        .Zip(routeValueArguments, (parameter, argument) => new
                                        {
                                            parameter,
                                            argument
                                        })
                                        .ToDictionary(kvp => kvp.parameter, kvp => kvp.argument);

            var routeValueDictionary = new RouteValueDictionary(rawRouteValueDictionary);

            string append = "";
            if (routeValues != null)
            {
                PropertyInfo[] pi = routeValues.GetType().GetProperties();
                foreach (PropertyInfo p in pi)
                {
                    if (!routeValueDictionary.ContainsKey(p.Name))
                    {
                        object o = p.GetMethod.Invoke(routeValues, null);
                        if (o is string && ((string)o).StartsWith("#"))
                        {
                            append = o.ToString();
                        }
                        else
                        {
                            routeValueDictionary.Add(p.Name, o);
                        }
                    }
                }
            }

            controller = methodCallExpression.Object.Type.Name;
            if (controller.ToLower().EndsWith("controller"))
                controller = controller.Substring(0, controller.Length - 10);

            var result = url.Action(action, controller, routeValueDictionary) + append;

            return result;
        }

        public static string GetDisplayAttributeValue<TEntity>(string propertyName)
        {
            string t = null;
            DisplayAttribute dAttr = typeof(TEntity).Attribute<DisplayAttribute>(propertyName);
            if (dAttr != null)
            {
                if (dAttr.Description != null)
                    t = dAttr.Description;
                else if (dAttr.Name != null)
                    t = dAttr.Name;
            }
            else if (t == null)
            {
                DescriptionAttribute dDesc = typeof(TEntity).Attribute<DescriptionAttribute>(propertyName);
                t = dDesc == null ? propertyName : dDesc.Description;
            }
            return t;
        }

        public static TAttribute GetAttribute<TObject, TAttribute>(string attributeName) where TAttribute : Attribute
        {
            return typeof(TObject).Attribute<TAttribute>(attributeName) as TAttribute;
        }

        /// <summary>
        /// Pega um objeto htmlAttributes, composto de atributos html como "new { @class="form-control" }"
        /// e retorna um dictionary onde o key seria "class", e o value seria "form-control"
        /// </summary>
        /// <param name="attributes"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ProcessHtmlAttributes(string attributes)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            if (!string.IsNullOrEmpty(attributes))
            {
                attributes = attributes.Trim('{', '}');
                if (!string.IsNullOrEmpty(attributes))
                {
                    string[] attrValuePairs = attributes.Split(',');
                    foreach (string attrValuePair in attrValuePairs)
                    {
                        var equalIndex = attrValuePair.IndexOf('=');
                        if (equalIndex > -1)
                        {
                            string attrName = attrValuePair.Substring(0, equalIndex).Trim();
                            string attrValue = attrValuePair.Substring(equalIndex + 1).Trim();
                            attrName = attrName.Replace("_", "-");
                            //var attrValue = attrValuePair.Split('=');
                            dict.Add(attrName, attrValue);
                        }
                    }
                }
            }
            return dict;
        }
        public static Dictionary<string, object> ProcessHtmlAttributes(object htmlAttributes)
        {
            Dictionary<string, object> attrs = new Dictionary<string, object>();
            //return ProcessHtmlAttributes(helper.AttributeEncode(htmlAttributes));
            if (htmlAttributes != null)
            {
                PropertyInfo[] properties = htmlAttributes.GetType().GetProperties();
                foreach (PropertyInfo prop in properties)
                {
                    attrs.Add(prop.Name.Replace('_', '-'), prop.GetValue(htmlAttributes, null));
                }
            }
            return attrs;
        }
        static string ToStyleAttribute(this Dictionary<string, string> dict)
        {
            if (dict.Count() > 0)
                return dict.Select(k => k.Key + ": " + k.Value).Join(";");
            else
                return "";
        }
        public static Dictionary<string, object> ProcessCssStyles(Dictionary<string, object> htmlAttributes)
        {
            Dictionary<string, object> d = new Dictionary<string, object>();

            if (htmlAttributes.ContainsKey("style"))
            {
                string style = ((string)htmlAttributes["style"]);

                if (!string.IsNullOrEmpty(style))
                {
                    string[] ss = style.Split(';');
                    foreach (string s in ss)
                    {
                        string[] ss2 = s.Split(':');
                        if (ss2.Length == 2)
                            d.Add(ss2[0].Trim(), ss2[1].Trim());
                    }
                }
            }

            return d;
        }

        static void MergeStyleElement(this Dictionary<string, object> dict, string name, string value)
        {
            Dictionary<string, string> styleElements = null;
            if (dict.ContainsKey("style"))
            {
                styleElements = ((string)dict["style"]).Split(';').Select(k => k.Trim()).Where(k => !string.IsNullOrEmpty(k)).Select(k =>
                {
                    string[] s = k.Split(':').Select(l => l.Trim()).Where(l => !string.IsNullOrEmpty(l)).ToArray();
                    return new KeyValuePair<string, string>(s[0], s[1]);
                }).ToDictionary(k => k.Key, k => k.Value);
            }
            else
                styleElements = new Dictionary<string, string>();

            if (!styleElements.ContainsKey(name))
                styleElements.Add(name, value);

            dict["style"] = styleElements.Select(k => k.Key + ": " + k.Value).Join("; ");
        }
        public static void AddCssClass(this Dictionary<string, object> dict, string _class, bool remove = false)
        {
            if (_class == null)
                return;

            _class = _class.Trim();

            List<string> classes = new List<string>();
            if (dict.ContainsKey("class"))
                classes = ((string)dict["class"]).Split(' ').Select(k => k.Trim()).Where(k => !string.IsNullOrEmpty(k)).ToList();

            if (classes.Contains(_class))
            {
                if (remove)
                    classes.Remove(_class);
            }
            else
                classes.Add(_class);

            string _classes = classes.Join(" ");

            if (dict.ContainsKey("class"))
                dict["class"] = _classes;
            else
                dict.Add("class", _classes);
        }
        public static void AddCssClass(this Dictionary<string, object> dict, string _class)
        {
            if (_class == null)
                return;

            _class = _class.Trim();

            List<string> classes = new List<string>();
            if (dict.ContainsKey("class"))
                classes = ((string)dict["class"]).Split(' ').Select(k => k.Trim()).Where(k => !string.IsNullOrEmpty(k)).ToList();
            if (!classes.Contains(_class))
                classes.Add(_class);

            string _classes = classes.Join(" ");

            if (dict.ContainsKey("class"))
                dict["class"] = _classes;
            else
                dict.Add("class", _classes);
        }
        public static void AddAttribute(this Dictionary<string, object> dict, string attr, object val, bool preserveUserSet = true)
        {
            if (dict.ContainsKey(attr))
            {
                if (preserveUserSet)
                    return;

                dict[attr] = val;
            }
            else
            {
                dict.Add(attr, val);
            }
        }

        static void MergeHtmlAttributes(ref TagBuilder builder, Dictionary<string, object> htmlAttributes)
        {
            foreach (KeyValuePair<string, object> attr in htmlAttributes)
            {
                if (!builder.Attributes.ContainsKey(attr.Key))
                {
                    builder.MergeAttribute(attr.Key, attr.Value.ToString());
                }
            }
        }
        static void MergeAttribute(string name, TagBuilder builder, Dictionary<string, string> attrs, string defaultValue)
        {
            string v = defaultValue;
            if (attrs.ContainsKey(name))
                v = attrs[name];
            builder.MergeAttribute(name, v);
        }
        public static HtmlString FloatingDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, SelectList selectList, object inputHtmlAttributes = null, object divHtmlAttributes = null)
        {
            Dictionary<string, object> attrs = ProcessHtmlAttributes(inputHtmlAttributes);
            attrs.AddAttribute("tag", "select", false);
            attrs.AddAttribute("selectList", selectList);

            return helper.FloatingLabelFor(expression, attrs, divHtmlAttributes);
        }
        public static HtmlString FloatingTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object inputHtmlAttributes = null, object divHtmlAttributes = null)
        {
            Dictionary<string, object> attrs = ProcessHtmlAttributes(inputHtmlAttributes);
            attrs.AddAttribute("tag", "input", false);

            return helper.FloatingLabelFor(expression, attrs, divHtmlAttributes);
        }
        public static HtmlString FloatingTextAreaFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object inputHtmlAttributes = null, object divHtmlAttributes = null)
        {
            Dictionary<string, object> attrs = ProcessHtmlAttributes(inputHtmlAttributes);
            attrs.AddAttribute("tag", "textarea", false);

            return helper.FloatingLabelFor(expression, attrs, divHtmlAttributes);
        }
        public static HtmlString FloatingEnumDropDownListFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, object inputHtmlAttributes = null, object divHtmlAttributes = null) where TProperty : Enum
        {
            //var modelExplorer = ModelMetadata.FromLambdaExpression(expression, helper.ViewData);

            TModel model = helper.ViewData.Model;
            TProperty property = default(TProperty);
            if (model != null)
            {
                Func<TModel, TProperty> func = expression.Compile();
                property = func(model);
            }

            Type type = typeof(TProperty);
            String[] Names = type.GetEnumNames();

            TProperty selectedValue = default(TProperty);

            Dictionary<string, TProperty> list = new Dictionary<string, TProperty>();

            foreach (string Name in Names)
            {
                TProperty thisVal = (TProperty)Enum.Parse(typeof(TProperty), Name);

                if (property != null && property.ToString().Equals(Name))
                    selectedValue = thisVal;

                string texto = thisVal.GetEnumDescription();

                list.Add(texto, thisVal);
            }

            SelectList sl = new SelectList(list, "Value", "Key", selectedValue);

            Dictionary<string, object> attrs = ProcessHtmlAttributes(inputHtmlAttributes);
            attrs.AddAttribute("tag", "select", false);
            attrs.AddAttribute("selectList", sl, false);

            return helper.FloatingLabelFor(expression, attrs, divHtmlAttributes);
        }
        static HtmlString FloatingLabelFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression, Dictionary<string, object> attrs, object divHtmlAttributes = null)
        {
            ModelExpressionProvider expressionProvider = new ModelExpressionProvider(helper.MetadataProvider);
            var metadata = expressionProvider.CreateModelExpression(helper.ViewData, expression);
            var modelExplorer = metadata.ModelExplorer;

            string name = modelExplorer.Metadata.Name;

            TagBuilder div = new TagBuilder("div");
            div.AddCssClass("form-floating mb-3");
            Dictionary<string, object> divAttrs = ProcessHtmlAttributes(divHtmlAttributes);
            MergeHtmlAttributes(ref div, divAttrs);

            string displayProp = ExtensoesSWM.GetDisplayAttributeValue<TModel>(name) ?? name;

            Dictionary<string, object> attrStyles = ProcessCssStyles(attrs);
            List<string> attrClasses = new List<string>();
            if (attrs.ContainsKey("class"))
                attrClasses = ((string)attrs["class"]).Split(' ').Select(k => k.Trim()).ToList();

            string tag = "input";
            string type = "text";

            if (attrs.ContainsKey("tag"))
                tag = ((string)attrs["tag"]);

            if (attrs.ContainsKey("type"))
                type = ((string)attrs["type"]);
            //if (input_type == "textarea")
            //    input_tag = "textarea";

            //TagBuilder input = new TagBuilder(input_tag);

            //var value = ModelMetadata.FromLambdaExpression(expression, helper.ViewData).Model;
            var value = metadata.Model;

            if (value is DateTime)
            {
                value = ((DateTime)value).AsYMDString();
                if (!attrs.ContainsKey("type"))
                    type = "date";

                attrs.AddCssClass("text-center");
            }

            // get the MaxLenght attribute from model
            if ((type == "text" || tag == "textarea") && !attrs.ContainsKey("maxlength"))
            {
                MaxLengthAttribute attr = GetAttribute<TModel, MaxLengthAttribute>("MaxLength");
                int len = 100;
                if (attr != null)
                    len = attr.Length;
                attrs.Add("maxlength", len.ToString());
            }

            attrs.AddCssClass("form-control");
            //input.MergeAttribute("type", input_type);
            //input.MergeAttribute("name", name);
            attrs.AddAttribute("id", name);
            attrs.AddAttribute("placeholder", displayProp);

            if (attrs.ContainsKey("value"))
                value = attrs["value"];

            //if (value != null)
            //{
            //    if (input_type == "textarea")
            //        input.InnerHtml = value;
            //    else
            //        input.MergeAttribute("value", value);
            //}

            //MergeHtmlAttributes(ref input, attrs);

            //if (attrStyles.Count() > 0)
            //    input.MergeAttribute("style", attrStyles.ToStyleAttribute());

            string inputStr = "";
            //inputStr = input.ToString();

            switch (tag)
            {
                case "input":
                    attrs.AddAttribute("type", type);

                    attrs.AddAttribute("value", value);

                    inputStr = helper.TextBox(name, value, attrs).ToString();
                    break;
                case "textarea":
                    //if (!attrStyles.ContainsKey("height"))
                    //    attrStyles.Add("height", "100px");

                    attrs.MergeStyleElement("height", "100px");
                    attrs.AddAttribute("value", value);

                    inputStr = helper.TextAreaFor(expression, attrs).ToString();
                    break;
                case "select":
                    SelectList list = attrs["selectList"] as SelectList;

                    attrs.AddCssClass("form-control", true);
                    attrs.AddCssClass("form-select");

                    attrs.AddAttribute("value", value);

                    inputStr = helper.DropDownListFor(expression, list, attrs).ToString();
                    break;
            }

            TagBuilder label = new TagBuilder("label");
            label.MergeAttribute("for", name);
            label.InnerHtml.Append(displayProp);

            div.InnerHtml.AppendHtml(inputStr + label.ToString() + helper.ValidationMessageFor(expression));

            return new HtmlString(div.ToString());
        }

        /// <summary>
        /// for <form class="form-horizontal"></form>
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="lblText"></param>
        /// <param name="formControl"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public static HtmlString FormHorizontal<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, HtmlString formControl, byte columns = 4)
        {
            ModelExpressionProvider expressionProvider = new ModelExpressionProvider(htmlHelper.MetadataProvider);
            var metadata = expressionProvider.CreateModelExpression(htmlHelper.ViewData, expression);
            var modelExplorer = metadata.ModelExplorer;

            string name = modelExplorer.Metadata.Name;

            byte lblColumns = 2;

            TagBuilder div = new TagBuilder("div");
            div.AddCssClass("form-group");

            string displayProp = ExtensoesSWM.GetDisplayAttributeValue<TModel>(name);

            TagBuilder lbl = new TagBuilder("label");
            lbl.MergeAttribute("for", name);
            lbl.AddCssClass("control-label col-sm-" + lblColumns.ToString());
            lbl.InnerHtml.AppendHtml(displayProp ?? name);

            TagBuilder div2 = new TagBuilder("div");
            div2.AddCssClass("col-sm-" + (columns - lblColumns).ToString());


            div2.InnerHtml.AppendHtml(formControl.ToString());
            div.InnerHtml.AppendHtml(lbl.ToString() + div2.ToString());

            return new HtmlString(div.ToString());

            //   < div class="form-group ">
            //	<label for="Id" class="col-sm-2 control-label">Id</label>
            //	<div class="col-sm-4">
            //		<input type = "number" class="form-control" id="Id" name="Id" style="width:60px" />
            //	</div>
            //</div>
        }
        public static HtmlString Conditional(this HtmlHelper html, bool condition, string ifTrue = "", string ifFalse = "")
        {
            string s = "";
            if (condition)
                s += ifTrue;
            else
                s += ifFalse;
            return new HtmlString(s);
        }

        public static IDisposable BeginFormHorizontal(this HtmlHelper html, string labelText, byte columns = 12, byte labelColumns = 3)
        {
            //<div class="form-group col-md-6">
            //<label class="col-sm-3 col-md-3 col-lg-2 control-label">Motivo</label>
            //<div class="col-sm-9 col-md-9 col-lg-10">
            //<select name = "EleicaoCargoMotivo" class="form-control" id="EleicaoCargoMotivo"><option selected = "selected" value="0">Renúncia</option><option value = "1" > Fim de Mandato</option><option value = "2" > Fim de Mandato/Nova Legislatura</option><option value = "3" > Fim de Mandato/Indicação Presidente</option></select>
            //</div>
            //</div>

            TextWriter w = html.ViewContext.Writer;
            w.WriteLine("<div class='form-group col-md-{0}'>\n".Format(columns));
            w.WriteLine("<label class='col-sm-{0} col-md-{1} col-lg-{2} control-label'>{3}</label>\n".Format(labelColumns, labelColumns, labelColumns - 1, labelText));
            w.WriteLine("<div class='col-sm-{0} col-md-{1} col-lg-{2}'>\n".Format(12 - labelColumns, 12 - labelColumns, 12 - labelColumns + 1));

            return new BeginHelperPostfix(html.ViewContext.Writer, "</div>\n</div>");
        }

        public static IDisposable BeginModal(this HtmlHelper html, string modalId, string title, HtmlString[] buttons, string bodyId = null)
        {
            /*
            <div id="modal" class="modal fade" tabindex="-1" role="dialog">
	            <div class="modal-dialog" role="document">
		            <div class="modal-content">
			            <div class="modal-header">
				            <button type="button" class="close" data-bs-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
				            <h4 class="modal-title">Ata</h4>
			            </div>
			            <div class="modal-body" id="modalBody">

			            </div>
			            <div class="modal-footer">
				            <button type="button" class="btn btn-default" data-bs-dismiss="modal">Fechar</button>
				            <button type="button" class="btn btn-primary" id="btnSave" onclick="saveItem()">Salvar</button>
			            </div>
		            </div><!-- /.modal-content -->
	            </div><!-- /.modal-dialog -->
            </div><!-- /.modal -->
            */

            TextWriter w = html.ViewContext.Writer;
            w.WriteLine(string.Format("<div id='{0}' class='modal fade' tabindex='-1' role='dialog'>", modalId));
            w.WriteLine("<div class='modal-dialog' role='document'>");
            w.WriteLine("<div class='modal-content'>");
            w.WriteLine("<div class='modal-header'>");
            w.WriteLine("<button type='button' class='close' data-bs-dismiss='modal' aria-label='Close'><span aria-hidden='true'>&times;</span></button>");
            w.WriteLine("<h4 class='modal-title'>" + title + "</h4>");
            w.WriteLine("</div>");
            bodyId = bodyId == null ? "" : " id='" + bodyId + "'";
            w.WriteLine("<div class='modal-body'" + bodyId + ">");

            string final =
                "</div>\n" +
                "<div class='modal-footer'>\n";
            foreach (HtmlString str in buttons)
                final += str.ToString();
            final += "</div>\n</div>\n</div>\n</div>";

            return new BeginHelperPostfix(html.ViewContext.Writer, final);
        }

        /// <summary>
        /// Usado em vários helpers destinados a uso aninhado (@using (Html....))
        /// Esse helper do tipo IDisposable permite fechar a tag escrevendo as tags de fechamento quando o aninhamento termina
        /// </summary>
        internal class BeginHelperPostfix : IDisposable
        {
            TextWriter _writer;
            string _text;
            public BeginHelperPostfix(TextWriter writer, string postHtml)
            {
                _writer = writer;
                _text = postHtml;
            }
            public void Dispose()
            {
                _writer.WriteLine(_text);
            }
        }
        public static IDisposable BeginHamburger(this HtmlHelper html)
        {
            //<div class="dropdown">
            //	<button class="btn btn-secondary dropdown-toggle" type="button" data-bs-toggle="dropdown">
            //		<span class="glyphicon glyphicon-menu-hamburger"></span>
            //		<span class="caret"></span>
            //	</button>
            //	<ul class="dropdown-menu">
            //		<li>@Html.ActionLink("Excluir", "Deletar", new { id = item.IdAta_Item })</li>
            //	</ul>
            //</div>        

            TextWriter w = html.ViewContext.Writer;
            w.WriteLine("<div class='dropdown'>");
            w.WriteLine("<button class='btn btn-secondary dropdown-toggle' type='button' data-bs-toggle='dropdown'>");
            w.WriteLine("<span class='glyphicon glyphicon-menu-hamburger'></span>");
            w.WriteLine("<span class='caret'></span>");
            w.WriteLine("</button>");
            //...<li>@Html.ActionLink("Excluir", "Deletar", new { id = item.IdAta_Item })</li>
            return new BeginHelperPostfix(w, "</div>\n");
        }
        public static IDisposable BeginFormGroup(this HtmlHelper html, string labelText, byte columns = 12)
        {
            //<div class='col-md-3'>
            //<label for="@nome">@nome</label>
            //...
            //</div>

            TagBuilder div = new TagBuilder("div");
            div.AddCssClass("col-md-" + columns.ToString());
            html.ViewContext.Writer.WriteLine();

            TagBuilder lbl = new TagBuilder("label");
            lbl.InnerHtml.AppendHtml(labelText);
            html.ViewContext.Writer.WriteLine(lbl.ToString());

            return new BeginHelperPostfix(html.ViewContext.Writer, div.ToString());
        }
        public static HtmlString IconActionLink<TModel>(this HtmlHelper<TModel> htmlHelper, string text, string url, string icon, string confirmMessage = null)
        {
            string iconClass = "";
            string tx = "";
            if (!string.IsNullOrEmpty(text))
            {
                iconClass = "btn btn-primary";
                tx = "<span>\n" + "<strong> {0}</strong>".Format(text) + "\n</span>";
            }
            string conf = "";
            if (!string.IsNullOrEmpty(confirmMessage))
            {
                conf = "onclick=\"return confirm('{0}')\"".Format(confirmMessage);
            }

            string s = "<a href=\"{0}\" class=\"{1}\" {2}>".Format(url, iconClass, conf);
            s += "<i class=\"{0}\"></i>".Format(icon);
            s += tx;
            s += "</a>";
            return new HtmlString(s);
        }
        public static HtmlString FormGroup<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, string labelText, HtmlString formControl, byte columns = 3)
        {
            //<div class='col-md-3'>
            //<label for="@nome">@nome</label>
            //...
            //</div>

            TagBuilder div = new TagBuilder("div");
            div.AddCssClass("col-md-" + columns.ToString());

            TagBuilder lbl = new TagBuilder("label");
            lbl.InnerHtml.AppendHtml(labelText);

            div.InnerHtml.AppendHtml(lbl.ToString() + formControl.ToString());

            return new HtmlString(div.ToString());
        }

        public static HtmlString FormGroupFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, HtmlString formControl, byte columns = 3)
        {
            //<div class='col-md-3'>
            //<label for="@nome">@nome</label>
            //...
            //</div>

            ModelExpressionProvider expressionProvider = new ModelExpressionProvider(htmlHelper.MetadataProvider);
            var metadata = expressionProvider.CreateModelExpression(htmlHelper.ViewData, expression);

            string name = metadata.Name;

            TagBuilder div = new TagBuilder("div");
            div.AddCssClass("col-md-" + columns.ToString());

            string displayProp = ExtensoesSWM.GetDisplayAttributeValue<TModel>(name);
            TagBuilder lbl = new TagBuilder("label");
            lbl.MergeAttribute("for", name);
            lbl.InnerHtml.AppendHtml(displayProp ?? name);

            div.InnerHtml.AppendHtml(lbl.ToString() + formControl.ToString());

            return new HtmlString(div.ToString());
        }

        public static HtmlString EnumDropDownListDescriptionFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TProperty>> expression, object htmlAttributes = null, string zeroValueText = null) where TProperty : Enum
        {
            //var modelExplorer = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            ModelExpressionProvider expressionProvider = new ModelExpressionProvider(htmlHelper.MetadataProvider);
            var metadata = expressionProvider.CreateModelExpression(htmlHelper.ViewData, expression);

            var modelExplorer = metadata.ModelExplorer;

            TModel model = htmlHelper.ViewData.Model;
            TProperty property = default(TProperty);
            if (model != null)
            {
                Func<TModel, TProperty> func = expression.Compile();
                property = func(model);
            }
            TagBuilder select = new TagBuilder("select");
            if (htmlAttributes != null)
            {
                System.Reflection.PropertyInfo[] properties = htmlAttributes.GetType().GetProperties();
                foreach (System.Reflection.PropertyInfo prop in properties)
                {
                    select.MergeAttribute(prop.Name, (String)prop.GetValue(htmlAttributes, null));
                }
            }
            Type type = typeof(TProperty);
            String[] Names = type.GetEnumNames();
            if (zeroValueText != null)
            {
                TagBuilder option = new TagBuilder("option");
                option.MergeAttribute("value", "0");
                option.InnerHtml.AppendHtml(zeroValueText);
                select.InnerHtml.AppendHtml(option.ToString());
            }
            foreach (string Name in Names)
            {
                TProperty thisVal = (TProperty)Enum.Parse(typeof(TProperty), Name);

                //System.Reflection.MemberInfo info = type.GetMember(Name).FirstOrDefault();
                TagBuilder option = new TagBuilder("option");
                if (property != null && property.ToString().Equals(Name))
                    option.MergeAttribute("selected", "selected");

                var t = thisVal.ToString();
                try
                {
                    option.MergeAttribute("value", ((short)Enum.Parse(typeof(TProperty), Name)).ToString());
                }
                catch (Exception e)
                {
                    try
                    {
                        option.MergeAttribute("value", ((byte)Enum.Parse(typeof(TProperty), Name)).ToString());
                    }
                    catch (Exception e2)
                    {
                        try
                        {
                            option.MergeAttribute("value", ((int)Enum.Parse(typeof(TProperty), Name)).ToString());
                        }
                        catch (Exception e3)
                        {
                            throw;
                        }
                    }
                }

                string texto = thisVal.GetEnumDescription();

                if (!string.IsNullOrEmpty(texto))
                    option.InnerHtml.Append(texto);
                else
                    option.InnerHtml.Append(Name);

                select.InnerHtml.AppendHtml(option.ToString());
            }
            if (!select.Attributes.Where(x => x.Key.ToLower().Equals("id")).Any())
                select.MergeAttribute("id", type.Name);

            if (!select.Attributes.Where(x => x.Key.ToLower().Equals("name")).Any())
            {
                string prefix = htmlHelper.ViewData.TemplateInfo.HtmlFieldPrefix;
                if (!string.IsNullOrEmpty(prefix)) prefix += ".";
                select.MergeAttribute("name", prefix + type.Name);
            }

            return new HtmlString(select.ToString());
        }

        public static TModel TentaEditar<TModel>(this DbContext _context, long? identity) where TModel : class, new()
        {
            TModel model;
            if (identity == null || identity == 0)
            {
                model = new TModel();
                //model = Activator.CreateInstance(typeof(TModel)) as TModel;
                if (model is IEntityInitialize)
                    ((IEntityInitialize)model).Initialize(_context);
            }
            else
            {
                model = _context.Set<TModel>()
                    .Find(identity);
            }
            return model;
        }

        public static void TentaExcluir<TModel>(this DbContext context, long id, Controller controller) where TModel : class
        {
            TModel entity = context.Set<TModel>().Find(id);
            if (entity == null)
                throw new KeyNotFoundException("Entity não encontrado: " + id.ToString());
            context.TentaExcluir(entity, controller);
        }
        public static void TentaExcluir<TModel>(this DbContext context, TModel model, Controller controller) where TModel : class
        {
            if (model is IEntityDestroy)
                ((IEntityDestroy)model).Destroy(context);
            context.Set<TModel>().Remove(model);
        }

        /// <summary>
        /// Return the value of a static property from type
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <param name="type"></param>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public static TData GetStaticPropertyValue<TData>(this Type type, string propertyName)
        {
            Type type2 = type.GetPOCOType();
            PropertyInfo pi = type2.GetProperty(propertyName, BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy);

            if (pi == null)
                return default(TData);
            return (TData)pi.GetValue(null, null);
        }

        /// <summary>
        /// Quando o objeto passado é um entityproxy do Entity Framework, retorna o tipo do entity original
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns></returns>
        public static Type GetPOCOType(this Type entityType)
        {
            if (entityType.Namespace == "Castle.Proxies")
            {
                return entityType.BaseType;
            }
            return entityType;

            //return System.Data.Entity.Core.Objects.ObjectContext.GetObjectType(entityType);
        }
        /// <summary>
        /// Em uma entity do Entity Framework, retorna o valor da propriedade Id
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static long GetIdentityValue(this object entity)
        {
            if (entity == null)
                return -1;

            PropertyInfo keyInfo = entity.GetType().GetPOCOType().GetProperties().FirstOrDefault(p =>
                p.CustomAttributes.Any(attr => attr.AttributeType == typeof(KeyAttribute)));
            if (keyInfo == null)
                return -1;
            return (long)keyInfo.GetValue(entity);
        }
        public static void SetIdentityValue(this object entity, long value)
        {
            if (entity == null)
                return;

            PropertyInfo keyInfo = entity.GetType().GetPOCOType().GetProperties().FirstOrDefault(p =>
                p.CustomAttributes.Any(attr => attr.AttributeType == typeof(KeyAttribute)));
            keyInfo.SetValue(entity, value);
        }

        public static TValue GetPropertyValue<TValue>(this object entity, string propertyName)
        {
            if (entity == null)
                return default(TValue);

            PropertyInfo pi = entity.GetType().GetPOCOType().GetProperties().FirstOrDefault(p => p.Name == propertyName);
            return (TValue)pi.GetValue(entity);
        }
        public static void SetPropertyValue<TValue>(this object entity, string propertyName, TValue value)
        {
            if (entity == null)
                return;

            PropertyInfo pi = entity.GetType().GetPOCOType().GetProperties().FirstOrDefault(p => p.Name == propertyName);
            pi.SetValue(entity, value);
        }

        /*
        // Faz update em uma árvore de entidades (a entidade passada por parâmetro e todas as suas propriedades que são listas de entidades)
        // Todos os objetos com identity = 0 são adicionados, com identity != 0 são marcados como modificados
        // o objeto e todas as suas proprieaddes são comparados com o banco de dados e os objetos faltantes são marcados como deleted
        public static void ProccessEntityEntryState<TEntity>(DbContext context, TEntity dbEntity, Node treeDescription) where TEntity : class
        {
            DbEntityEntry entry = context.Entry(dbEntity);

            if (treeDescription == null)
                treeDescription = new Node();

            // para cada propriedade do objeto que é do tipo ICollection<>
            foreach (Node prop in treeDescription.Children)
            {
                // para cada item na coleção, verifica se o ítem foi adicionado (id=0) ou modificado (id != 0)
                IEnumerable collection = (IEnumerable)entry.Collection(prop.Name).CurrentValue;
                if (collection != null)
                {
                    foreach (var entity in collection)
                        ProccessEntityEntryState(context, entity, prop);
                }
            }

            // verifica se a entidade principal (passada por parâmetro) foi modificada ou adicionada
            long key = GetIdentityValue(dbEntity);
            if (key == 0)
            {
                entry.State = EntityState.Added;

                if (dbEntity is IEntityInitialize)
                    ((IEntityInitialize)dbEntity).Initialize(context);
            } else
                entry.State = EntityState.Modified;

            // se o objeto principal acabou de ser adicionado ou não está anexado, não poderia
            // ter ítems relacionados para excluir...
            if (entry.State == EntityState.Added || entry.State == EntityState.Detached)
                return;

            foreach (Node prop in treeDescription.Children)
            {
                DbCollectionEntry collection = entry.Collection(prop.Name);
                if (collection != null)
                {
                    IEnumerable list = (IEnumerable)collection.CurrentValue;
                    collection.Load();
                    List<object> deleted = new List<object>();
                    foreach (var entity in list)
                    {
                        if (context.Entry(entity).State == EntityState.Unchanged)
                            deleted.Add(entity);
                    }
                    foreach (object entity in deleted)
                        context.Entry(entity).State = EntityState.Deleted;
                }
            }
        }
        
        /// <summary>
        /// Tenta salvar uma entidade e outras entidades relacionadas
        /// Para salvar somente o objeto, sem entidades relacionadas, passar null no collectionMap
        /// Para salvar entidades relacionadas, usa estrutura do tipo tree que pode ser escrita em formato json, com as propriedades
        /// string Nome: o nome da Coleção
        /// Node[] Children: uma array de Node que representa as coleções relacionadas que também precisam ser salvas junto
        /// "{Name:'Chapas', Children: [{Name: 'Candidatos'}, {Name:'VotosFavoraveis'}]}");
        /// </summary>
        public static ActionResult TentaSalvar<TModel>(this DbContext _contexto, TModel entity, Controller controller, Func<ActionResult> success, Func<ActionResult> error = null, string collectionMap = null) where TModel : class
        {
            Node n = null;
            if (!string.IsNullOrEmpty(collectionMap))
                n = Node.Decode(collectionMap);

            ProccessEntityEntryState(_contexto, entity, n);
            return _contexto.SaveChanges(controller, success, error);
        }
        */

        /// <summary>
        /// Exclui uma entidade do banco de dados quando ela não for encontrada na coleção enviada pelo view
        /// Se outras ações forem necessárias quando a entidade é excluída, use IEntityDestroy
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="context"></param>
        /// <param name="detachedCollection">A coleção recebida do view</param>
        /// <param name="existingEntity">A entidade encontrada no banco de dados. Essa entidade é procurada no detachedCollection. Se não encontrada, é excluida do banco de dados.</param>
        public static TEntity deleteEntity<TEntity>(this DbContext context, ICollection<TEntity> detachedCollection, TEntity existingEntity) where TEntity : class
        {
            Func<TEntity> onFind = () =>
            {
                long existingId = existingEntity.GetIdentityValue();
                return detachedCollection == null ? null : detachedCollection.FirstOrDefault(k => k.GetIdentityValue() == existingId);
            };
            return context.deleteEntity(onFind, existingEntity);
        }
        /// <summary>
        /// Exclui uma entidade do banco de dados
        /// Se outras ações forem necessárias quando a entidade é excluída, use IEntityDestroy
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="context"></param>
        /// <param name="detachedCollection">A coleção recebida do view</param>
        /// <param name="existingEntity">A entidade encontrada no banco de dados. Essa entidade é procurada no detachedCollection. Se não encontrada, é excluida do banco de dados.</param>
        public static TEntity deleteEntity<TEntity>(this DbContext context, TEntity existingEntity) where TEntity : class
        {
            Func<TEntity> onFind = () =>
            {
                return null;
            };
            return context.deleteEntity(onFind, existingEntity);
        }
        /// <summary>
        /// Exclui uma entidade do banco de dados
        /// Se outras ações forem necessárias quando a entidade é excluída, use IEntityDestroy
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="context"></param>
        /// <param name="detachedCollection">A coleção recebida do view</param>
        /// <param name="existingEntity">A entidade encontrada no banco de dados. Essa entidade é procurada no detachedCollection. Se não encontrada, é excluida do banco de dados.</param>
        public static TEntity deleteEntity<TEntity>(this DbContext context, long existingId) where TEntity : class
        {
            TEntity existingEntity = context.Set<TEntity>().Find(existingId);
            Func<TEntity> onFind = () =>
            {
                return null;
            };
            return context.deleteEntity(onFind, existingEntity);
        }
        static TEntity deleteEntity<TEntity>(this DbContext context, Func<TEntity> onFind, TEntity existingEntity) where TEntity : class
        {
            TEntity detachedEntity = onFind?.Invoke();
            if (detachedEntity == null)
            {
                context.Entry(existingEntity).State = EntityState.Deleted;
                if (existingEntity is IEntityDestroy)
                    (existingEntity as IEntityDestroy).Destroy(context);
            }
            return detachedEntity;
        }

        public static TEntity updateEntity<TEntity>(this DbContext context, TEntity detachedEntity) where TEntity : class
        {
            DbSet<TEntity> existingCollection = context.Set<TEntity>();

            long detachedId = detachedEntity.GetIdentityValue();

            return updateEntity(context,
                () => detachedId > 0 ? existingCollection.Find(detachedEntity.GetIdentityValue()) : null,
                null,
                detachedEntity);
        }

        public static TEntity2 updateEntity<TEntity, TEntity2>(this DbContext context, ICollection<TEntity2> existingCollection, TEntity detachedEntity) where TEntity : class where TEntity2 : class
        {
            long detachedId = detachedEntity.GetIdentityValue();
            return updateEntity(context,
                () => detachedId > 0 ? existingCollection.FirstOrDefault(k => k.GetIdentityValue() == detachedId) : null,
                (existingEntity) => existingCollection.Add(existingEntity),
                detachedEntity);
        }

        private static TEntity2 updateEntity<TEntity, TEntity2>(DbContext context, Func<TEntity2> onFind, Action<TEntity2> onAdd, TEntity detachedEntity) where TEntity : class where TEntity2 : class
        {
            if (detachedEntity == null)
                return null;

            TEntity2 existingEntity = onFind();
            if (existingEntity == null)
            {
                Type entityType = typeof(TEntity);
                existingEntity = Activator.CreateInstance(entityType) as TEntity2;
                //existingEntity = new TEntity();
                context.Set<TEntity2>().Attach(existingEntity);
                context.Entry(existingEntity).CurrentValues.SetValues(detachedEntity);
                context.Entry(existingEntity).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                onAdd?.Invoke(existingEntity);
            }
            else
                context.Entry(existingEntity).CurrentValues.SetValues(detachedEntity);

            if (existingEntity is IEntityUpdate)
                ((IEntityUpdate)existingEntity).Update(context);

            return existingEntity;
        }

    }
}

namespace System.Linq
{
    public static class LinqExtensios
    {
        public static IEnumerable<T> Except<T>(this IEnumerable<T> items, Func<T, bool> except)
        {
            foreach (T item in items)
                if (!except(item))
                    yield return item;
        }
        public static IEnumerable<T> Parents<T>(this T item, Func<T, T> parent)
        {
            T i = item;
            var nodes = new Stack<T>();
            while (i != null)
            {
                nodes.Push(i);
                i = parent(i);
            }
            return nodes;
        }
        public static IEnumerable<T> Descendants<T>(this T root, Func<T, IEnumerable<T>> childs)
        {
            var nodes = new Queue<T>(new[] { root });
            while (nodes.Any())
            {
                T node = nodes.Dequeue();
                yield return node;
                IEnumerable<T> c = childs(node);
                if (c != null)
                    foreach (T n in c) nodes.Enqueue(n);
            }
        }

        public static IQueryable<TSource> OfType<TSource>(this IQueryable<TSource> queryable,
                Type runtimeType)
        {
            var method = typeof(Queryable).GetMethod(nameof(Queryable.OfType));
            var generic = method.MakeGenericMethod(new[] { runtimeType });
            return (IQueryable<TSource>)generic.Invoke(null, new[] { queryable });
        }
        public static int IndexOf<T>(this IEnumerable<T> lista, T targetValue)
        {
            return lista.Select((value, index) => new { value, index })
                        .Where(pair => pair.value.Equals(targetValue))
                        .Select(pair => pair.index + 1)
                        .FirstOrDefault() - 1;
        }
    }
}

namespace System.Web
{
    public static class SystemWebExtensions
    {
        //public static bool IsLocal(this HttpSessionStateBase session)
        //{
        //}

        //public static bool IsLocal(this HttpResponseBase response, string password)
        //{
        //    string nomeCookie = "psUserLogin";

        //    if (password == "logout")
        //    {
        //        response.Cookies[nomeCookie].Expires = DateTime.Now.AddDays(-1);
        //        return false;
        //    }

        //    // create cookie
        //    if (password != "9763pros")
        //        return false;

        //    // Verificando se já existe o cookie na máquina do usuário
        //    HttpCookie cookie = response.Cookies[nomeCookie];

        //    //if (cookie != null)
        //    //{
        //    //    cook request.Cookies[nomeCookie].Expires = DateTime.Now.AddDays(-1);
        //    //    //cookie = null;
        //    //}

        //    if (cookie == null)
        //        // Criando a Instância do cookie
        //        cookie = new HttpCookie(nomeCookie);
        //    //Adicionando a propriedade "Nome" no cookie
        //    cookie.Values.Add("validEntry", password);
        //    //colocando o cookie para expirar em 365 dias
        //    cookie.Expires = DateTime.Now.AddDays(1);
        //    // Definindo a segurança do nosso cookie
        //    cookie.HttpOnly = true;
        //    // Registrando cookie
        //    response.AppendCookie(cookie);
        //    return true;
        //}

        /// <summary>
        /// Retorna se o computador que chamou o Request está no mesmo endereço de rede do servidor.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        //public static bool IsLocalHost(this HttpRequestBase request)
        //{
        //    return request.UserHostAddress.StartsWith("192.168") || request.UserHostAddress.StartsWith("::1");
        //}

        public static void LogOut(this ISession session)
        {
            session.SetString("usuarioLogadoID", null);
            session.SetString("usuarioLogadoNome", null);
        }
        public static bool IsLogged(this ISession session)
        {
            return session.GetString("usuarioLogadoID") != null;
        }
        public static void Login(this ISession session, int id, string nome)
        {
            session.SetInt32("usuarioLogadoID", id);
            session.SetString("usuarioLogadoNome", nome);
        }
        public static string LoggedUser(this ISession session)
        {
            return session.GetString("usuarioLogadoNome");
        }
        /// <summary>
        /// if password == "logout" delete cookie
        /// </summary>
        /// <param name="request"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        //public static bool IsLocal(this HttpRequestBase request, string password = null)
        //{
        //    string nomeCookie = "psUserLogin";
        //    // read cookie
        //    if (password == null)
        //    {
        //        try
        //        {
        //            HttpCookie cookie = request.Cookies[nomeCookie];
        //            if (cookie != null) {
        //                string val = cookie.Value.ToString();
        //                int idx = val.IndexOf("=");
        //                if (idx > -1)
        //                {
        //                    val = val.Substring(idx+1);
        //                    if (val == "9763pros")
        //                        return true;
        //                }
        //                return false;
        //            }
        //            else
        //                return false;
        //        } 
        //        catch
        //        {}
        //        return false;
        //    }
        //    // delete cookie
        //    else if (password == "logout") {
        //        request.Cookies[nomeCookie].Expires = DateTime.Now.AddDays(-1);
        //        return false;
        //    }
        //    return false;
        //    //return request.UserHostAddress.StartsWith("192.168") || request.UserHostAddress.StartsWith("::1");
        //}
        public static string CheckUploadDuplicated(this IFormFile file, string nomeAtualDoArquivo, string novoNomeDoArquivo, string basepath)
        {

            //if (!string.IsNullOrEmpty(savedFilePropertyValue) && currentFilePropertyValue == savedFilePropertyValue && file == null)
            //    return savedFilePropertyValue;

            // se o form enviou um arquivo, salva o arquivo e devolve o nome do arquivo que foi salvo
            if (file != null)
            {
                Dictionary<string, string> dict = (new IFormFile[] { file }).PerformUploads(basepath);
                novoNomeDoArquivo = dict.First().Value;
            }
            else
            {
                // se tinha um nome de arquivo 
                if (!string.IsNullOrEmpty(nomeAtualDoArquivo))
                {
                    // se o novo nome de arquivo é vazio, apaga a imagem do disco
                    if (string.IsNullOrEmpty(novoNomeDoArquivo))
                    {
                        string fn = basepath + nomeAtualDoArquivo;
                        if (File.Exists(fn))
                            File.Delete(fn);
                    }
                    // se o nome do arquivo mudou, mas ele não foi enviado em upload, deve permanecer o antigo
                    else
                    {
                        novoNomeDoArquivo = nomeAtualDoArquivo;
                    }
                }
            }
            return novoNomeDoArquivo;
        }

        public static Dictionary<string, string> PerformUploads(this IFormFile[] files, string basepath)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            var newFileName = string.Empty;

            if (files != null)
            {
                foreach (var file in files)
                {
                    if (file != null && file.Length > 0)
                    {
                        string fn = Path.GetFileNameWithoutExtension(file.FileName);
                        string ext = Path.GetExtension(file.FileName);

                        newFileName = fn;
                        int index = 1;
                        while (System.IO.File.Exists(Path.Combine(basepath, newFileName + ext)))
                        {
                            newFileName = fn + " (" + (index++).ToString() + ")";
                        }

                        dict.Add(fn + ext, newFileName + ext);

                        string _path = Path.Combine(basepath, newFileName + ext);

                        using (var stream = new FileStream(_path, FileMode.Create))
                        {
                            file.CopyToAsync(stream);
                        }
                    }
                }
            }

            return dict;
        }
    }
}

namespace System.Collections.Generic
{
    public static class SystemCollectionsGenericExtensions
    {
        public static string Join(this IEnumerable<string> items, string separator, string lastseprator = null)
        {
            if (items.Count() == 0) return "";
            if (items.Count() == 1) return items.ElementAt(0);

            if (lastseprator == null)
            {
                lastseprator = separator;
            }

            string ret = "";
            string[] itm = items.ToArray();
            for (int i = 0; i < items.Count() - 2; i++)
            {
                ret += itm[i];
                ret += separator;
            }
            if (itm.Length > 1)
            {
                ret += itm[itm.Length - 2] + lastseprator + itm[itm.Length - 1];
            }
            return ret;
        }
        public static dynamic ToDynamic(this IDictionary<string, object> pars)
        {
            var eo = new System.Dynamic.ExpandoObject();
            var eoColl = (ICollection<KeyValuePair<string, object>>)eo;
            foreach (var kvp in pars as IDictionary<string, object>)
            {
                eoColl.Add(kvp);
            }
            return eo;
        }
    }
}

namespace System
{
    public class MySelection<T>
    {
        public MySelection(string text, T value)
        {
            this.Text = text;
            this.Value = value;
        }
        public string Text { get; set; }
        public T Value { get; set; }
    }

    public static class MyExtension
    {
        public static string FormatAnchor(string link, string text)
        {
            return "<a target=\"_blank\" href=\"" + link + "\">" + text + "</a>";
        }

        public static object CallJSONService(this Type type, string action, object dataToSend)
        {
            object ret = null;
            //try {
            System.Reflection.MethodInfo mi = type.GetMethod(
                action,
                System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public,
                null,
                new Type[] { typeof(object) },
                null);
            ret = mi.Invoke(null, new object[] { dataToSend });
            //} catch (Exception ex) {
            //  ret = ex;
            //}
            return ret;
        }

        // only for asp.net
        public static Type GetType(string typeName)
        {
            IEnumerable<Type> types = null;
            try
            {
                var dom = AppDomain.CurrentDomain;
                var asm = dom.GetAssemblies();
                types = asm.SelectMany(k => k.GetTypes());
            }
            catch { }



            //            var alltypes = AppDomain.CurrentDomain.GetAssemblies().SelectMany(asm=>asm.GetTypes());

            return types.FirstOrDefault(tp => tp.ToString().Contains("." + typeName));
        }




        //public static EntityType GetCSpaceEntityType<T>(this MetadataWorkspace workspace) 
        //{ 
        //    if (workspace == null)  
        //        throw new ArgumentNullException("workspace"); 
        //    // Make sure the assembly for "T" is loaded 
        //    workspace.LoadFromAssembly(typeof(T).Assembly); 
        //    // Try to get the ospace type and if that is found 
        //    // look for the cspace type too. 
        //    EntityType ospaceEntityType = null; 
        //    StructuralType cspaceEntityType = null; 
        //    if (workspace.TryGetItem<EntityType>( 
        //        typeof(T).FullName,  
        //        DataSpace.OSpace, 
        //        out ospaceEntityType)) 
        //    { 
        //        if (workspace.TryGetEdmSpaceType( 
        //            ospaceEntityType, 
        //            out cspaceEntityType)) 
        //        { 
        //            return cspaceEntityType as EntityType; 
        //        } 
        //    } 
        //    return null; 
        //}

        //public static T GetId<T, K>(this ObjectQuery<T> query, K key) 
        //{ 
        //    //Get the EntityType 
        //    EntityType entityType = query.Context.MetadataWorkspace.GetCSpaceEntityType<T>(); 

        //    if (entityType.KeyMembers.Count != 1) 
        //        throw new Exception("You need to pass all the keys"); 

        //    //Build the ESQL 
        //    string eSQL = string.Format("it.{0} = @{0}", 
        //                                entityType.KeyMembers[0].Name);

        //    try
        //    {
        //        //Execute the query 
        //        return query.Where(
        //            eSQL,
        //            new ObjectParameter(entityType.KeyMembers[0].Name, key)
        //        ).First();
        //    }
        //    catch {
        //        return default(T);
        //    }
        //}

        //public static T As<T>(this object obj, T defaultValue)
        //{
        //    Type nt = typeof(T);
        //    return (T)Convert.ChangeType(obj, nt);
        //}

        //public static T Entity<T>(this HttpRequestBase request, ObjectQuery<T> lista, string requestStr) {
        //    long id = request[requestStr].As<long>(-1);
        //    return lista.GetId<T, long>(id);
        //}

        //public static System.Data.EntityClient.EntityConnection BuildEntityConnection(string dbFileName, string resourceData, string password) {

        //  string dataSource = @"Data Source=|DataDirectory|" + "\\" + dbFileName;

        //  System.Data.EntityClient.EntityConnectionStringBuilder entityBuilder = new System.Data.EntityClient.EntityConnectionStringBuilder();

        //  //entityBuilder.Metadata = "res://*/App_Code.EmpModel.csdl|res://*/App_Code.EmpModel.ssdl|res://*/App_Code.EmpModel.msl";

        //  entityBuilder.Metadata = string.Format("res://*/{0}.csdl|res://*/{0}.ssdl|res://*/{0}.msl", resourceData);



        //  entityBuilder.Provider = "System.Data.SqlServerCe.4.0";

        //  if (String.IsNullOrEmpty(password)) {
        //    entityBuilder.ProviderConnectionString = dataSource;
        //  } else {
        //    entityBuilder.ProviderConnectionString = dataSource + ";Password=" + password;
        //  }
        //  System.Data.EntityClient.EntityConnection con = new System.Data.EntityClient.EntityConnection();

        //    con.ConnectionString = entityBuilder.ToString();
        //    con.Open();
        //    return con;
        //}

        //public static HtmlString CreateGrid<T>(this IEnumerable<object> lista, string urlServicos, string divGridId, string divDialogId, Func<T, long> idfunc, string gridId, string gridWidth, bool IsAuthenticated, HtmlHelper Html, string imagePath, string onedit, string ondelete, string moreData, params ExtGridCol<T>[] colunas) {

        //    string editHint = "Editar " + typeof(T).Description();
        //    string deleteHint = "Excluir " + typeof(T).Description();
        //    string deleteMessage = "Confirma a exclusão do(a) " + typeof(T).Description() + "?";

        //    // primeira coluna, chamada id, contém o id do objeto
        //    //ExtGridCol<T> idcol = new ExtGridCol<T>("id", "id", k=> string.Format("<input type='hidden' name='id' value='{0}'/>", idfunc(k)));
        //    //List<ExtGridCol<T>> list = colunas.ToList();
        //    //list.Insert(0, idcol);
        //    //colunas = list.ToArray();
        //    List<WebGridColumn> columns = new List<WebGridColumn>();
        //    if (idfunc != null) {
        //        columns.Add(new WebGridColumn {Format = (a)=>idfunc(a.Value), Style = "HiddenCol" });
        //    }
        //    foreach (ExtGridCol<T> col in colunas) {
        //        columns.Add(new WebGridColumn { ColumnName = col.ColName, Header = col.Header, Format = (a) => col.Format(((T)a.Value)), Style = col.Style });
        //    }

        //    string[] cols = colunas.Select(k=>k.ColName).ToArray();
        //    WebGrid grid = new WebGrid(lista, columnNames : cols);

        //    if (IsAuthenticated) {

        //        string md = string.IsNullOrEmpty(moreData) ? "" : ", "+moreData;
        //        md = md.Replace('{', '▒').Replace('}', '▓');

        //        if (string.IsNullOrEmpty(onedit)) {
        //            onedit = string.Format("return Get('{0}',{1},'{2}'{3})", urlServicos, "{0}", divDialogId, md);
        //        }
        //        if (string.IsNullOrEmpty(ondelete)) {
        //            ondelete = string.Format("return Delete('{0}',{1}, '{2}', '{3}'{4})", urlServicos, "{0}", deleteMessage, divGridId, md);
        //        } 

        //        if (!string.IsNullOrEmpty(editHint) && idfunc != null) {
        //            columns.Add(new WebGridColumn { Format = (item)=>MyExtension.ImageButton(Html, imagePath + "edit.png", string.Format(onedit, idfunc(((T)item.Value))).Replace('▒','{').Replace('▓','}'), editHint), Style="GridImg"});
        //        }
        //        if (!string.IsNullOrEmpty(deleteMessage) && idfunc != null) {
        //            columns.Add(new WebGridColumn { Format = (item)=>MyExtension.ImageButton(Html, imagePath + "delete.png", string.Format(ondelete, idfunc(((T)item.Value))).Replace('▒','{').Replace('▓','}'), deleteHint), Style="GridImg"});
        //        }
        //    }

        //    return grid.GetHtml("table", "header", alternatingRowStyle:"alternate", columns: columns, htmlAttributes: new {style="width: " + gridWidth, id = gridId});
        //}

        //public static Type[] Subclasses(this Type tipo) {
        //    var tipos = AppDomain.CurrentDomain.GetAssemblies().SelectMany(k=> {
        //        Type[] ret = null;
        //        try { 
        //            ret = k.GetTypes();
        //        } catch (Exception ex) {
        //            return null;
        //        }
        //        return ret;
        //    }).Where(k=>k != null);
        //    var tp = tipos.Where(k=>k.IsSubclassOf(tipo) && !k.IsAbstract);
        //    return tp.OrderBy(k=>k.Description()).ToArray();
        //}


        /// <summary>
        /// Retorna o gênero associado à classe através do atributo TypeGenero
        /// </summary>
        /// <param name="type">A classe a ser testada</param>
        /// <param name="plural">Se o gênero a ser retornado é no singular ou no plural</param>
        /// <returns>O gênero da classe</returns>
        public static string Genero(this Type type, bool plural = false)
        {
            GeneroAttribute tg = type.GetCustomAttributes(typeof(GeneroAttribute), true).FirstOrDefault() as GeneroAttribute;
            if (tg != null)
                return tg.Genero(plural);
            else
                return null;
        }

        ///// <summary>
        ///// Retorna uma descrição curta, em poucas letras, que pode ser usada como identificador único da classe
        ///// </summary>
        ///// <param name="type"></param>
        ///// <returns></returns>
        //public static string SelectId(this Type type) {
        //    SelectId si = type.GetCustomAttributes(typeof(SelectId), true).FirstOrDefault() as SelectId;
        //    if (si != null)
        //        return si.Id;
        //    else
        //        return null;
        //}
        public static string SendEmail(string destEmail, string assunto, string corpo)
        {
            string errorMessage = null;
            try
            {
                // Initialize WebMail helper
                WebMail.SmtpServer = "smtp-mail.outlook.com";
                WebMail.SmtpPort = 587;
                WebMail.EnableSsl = true;
                WebMail.UserName = "camaraivora@hotmail.com";
                WebMail.Password = "presidente";
                WebMail.From = "camaraivora@hotmail.com";

                // Send email
                WebMail.Send(to: destEmail,
                    subject: assunto,
                    body: corpo,
                    isBodyHtml: true
                );
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
            }
            return errorMessage;
        }

        public static IEnumerable<MySelection<T>> ToMySelection<T>(this IEnumerable<T> list, Func<T, string> textFunc)
        {
            return list.Select(k => new MySelection<T>(textFunc(k), k));
        }

        //public static HtmlString DrawList<T>(this HtmlHelper helper, ListField<T>[] fields, IEnumerable<T> lista, string tableWidth = "auto", HtmlAttributes Attributes = null, HtmlAttributes RowAttributes = null)
        //{
        //    if (Attributes == null) {Attributes = new HtmlAttributes();}
        //    if (Attributes.Style.Width == null) {Attributes.Style.Width = tableWidth;}
        //    string attr = " " + Attributes.ToString();

        //    string rattr = RowAttributes == null ? "": RowAttributes.ToString();

        //    string s = string.Format("<table class='DataTable'{0}><thead>", attr);
        //    s += "<tr>";
        //    foreach (ListField<T> h in fields)
        //    {
        //        s += "<td>" + h.Title + "</td>";
        //    }
        //    s += "</tr></thead><tbody>";
        //    string stripes = "tr1";
        //    string otherClass = "";
        //    if (RowAttributes != null && !string.IsNullOrEmpty(RowAttributes.CssClass)) {
        //        otherClass = " " + RowAttributes.CssClass;
        //    }
        //    foreach (T objeto in lista)
        //    {
        //        s += "<tr class=\"" + stripes + otherClass + "\" " + rattr + ">";
        //        foreach (ListField<T> data in fields)
        //        {
        //            object value = data.Value(objeto);
        //            s += "<td>" + value.ToString() + "</td>";
        //        }
        //        s += "</tr>";
        //        stripes = stripes == "tr1" ? "tr2" : "tr1";
        //    }
        //    s += "</tbody></table>";
        //    return new HtmlString(s);
        //}

        public static string ObjectToHTMLAttributes(object HTMLAttributes, bool stylemode = false)
        {
            string s = "";

            if (HTMLAttributes != null)
            {
                System.Reflection.PropertyInfo[] fa = HTMLAttributes.GetType().GetProperties();
                for (int i = 0; i < fa.Count(); i++)
                {
                    System.Reflection.PropertyInfo fi = fa[i];

                    DescriptionAttribute da = fi.GetCustomAttributes(typeof(DescriptionAttribute), false).FirstOrDefault() as DescriptionAttribute;
                    string fn = da == null ? fi.Name : da.Description;

                    //if (fi.Name == "cssclass") { fn = "class"; }

                    object value = fi.GetValue(HTMLAttributes);

                    if (value != null)
                    {
                        if (stylemode)
                        {
                            if (s.Length > 0) { s += "; "; }
                            s += string.Format("{0}: {1}", fn, value);
                        }
                        else
                        {
                            if (s.Length > 0) { s += " "; }
                            s += string.Format("{0}=\"{1}\"", fn, value);
                        }
                    }
                }
            }
            return s;
        }
    }
    /*
    public static class HtmlHelpers {
        public static HtmlString ValidationSummary(this HtmlHelper helper)
        {
            return helper.Validation("Validation");
        }
        public static HtmlString Validation(this HtmlHelper helper, string message, string tipo = "info")
        {
            string s = "";
            if (helper != null && helper.ValidationSummary() != null)
            {
                s += helper.ValidationSummary().ToHtmlString();
            }
            if (message != null)
            {
                s += string.Format("<p class=\"message {0}\">{1}</p>", tipo, message);
            }
            return new HtmlString(s);
        }
        // HTMLAttributes: new { value = "teste", id = "aid", cssclass = "classe", onclick = "asfd";
        public static HtmlString Button(this HtmlHelper helper, object HTMLAttributes = null)
        {
            string s = ObjectToHTMLAttributes(HTMLAttributes);
            return new HtmlString("<Input type=\"button\"" + s + "/>");
        }
        public static HtmlString Button(this HtmlHelper helper, string name, string cssclass = null, object HTMLAttributes = null)
        {
            string s = ObjectToHTMLAttributes(HTMLAttributes);

            if (cssclass == null)
            {
                cssclass = "";
            }
            else
            {
                cssclass = " class=\"" + cssclass + "\"";
            }

            return new HtmlString("<Input type=\"button\" name=\"" + name + "\"" + cssclass + " " + s + "/>");
        }
        public static HtmlString DropDownListFor<T>(this HtmlHelper helper, string name, IEnumerable<MySelection<T>> lista, string selectedValue = null, object selectHtmlAttributes = null, object optionHtmlAttributes = null)
        {
            return helper.DropDownListFor<MySelection<T>>(name, lista, (l) => l.Text, (l) => l.Value, selectedValue, selectHtmlAttributes, optionHtmlAttributes);
        }
        public static HtmlString DropDownListFor<T>(this HtmlHelper helper, string name, IEnumerable<T> list, Func<T, string> text = null, Func<T, object> value = null, object selectedValue = null, object selectHtmlAttributes = null, object optionHtmlAttributes = null)
        {
            string sh = ObjectToHTMLAttributes(selectHtmlAttributes);
            string so = ObjectToHTMLAttributes(optionHtmlAttributes);

            Func<T, string> atext = text == null ? ((s1) => s1 == null ? null : s1.ToString()) : text;
            Func<T, object> avalue = value == null ? (s1) => s1 : value;

            string s = "<select name=\"" + name + "\" " + sh + ">";
            if (list != null && list.Count() > 0)
            {
                foreach (T o in list)
                {
                    string selected = "";
                    string val = "";
                    if (o != null)
                    {
                        object v = avalue(o);
                        val = v == null ? "" : v.ToString();
                        if (val.Equals(selectedValue))// != null && selectedValue == val)
                        {
                            selected = " selected";
                        }
                    }

                    s += "<option " + so + " value=\"" + val + "\"" + selected + ">" + atext(o) + "</option>";
                }
            }
            s += "</select>";
            return new HtmlString(s);
        }
        // insere um conjunto de divs usados para mostrar as pequenas janela ajax
        public static HtmlString ResultContainer(this HtmlHelper helper)
        {
            string s = "<div id=\"resultWindow\" class=\"resultWindowStyle\">";
            s += "<div id=\"btnFechaWindow\" ></div>";
            s += "<div id=\"resultContainer\" ></div>";
            s += "</div>";
            return new HtmlString(s);
        }
    }
    */
    public class TextWrittenEventArgs : EventArgs
    {
        public string Text { get; private set; }
        public TextWrittenEventArgs(string text)
        {
            this.Text = text;
        }
    }

    public class DebugMessages
    {
        StringBuilder _debugBuffer = new StringBuilder();

        public DebugMessages()
        {
            Debug.OnWrite += delegate (object sender, TextWrittenEventArgs e) { _debugBuffer.Append(e.Text); };
        }

        public override string ToString()
        {
            return _debugBuffer.ToString();
        }
    }

    public static class Debug
    {
        public delegate void OnWriteEventHandler(object sender, TextWrittenEventArgs e);
        public static event OnWriteEventHandler OnWrite;

        public static void Write(string text)
        {
            TextWritten(text);
        }

        public static void WriteLine(string text)
        {
            TextWritten(text + System.Environment.NewLine);
        }

        public static void Write(string text, params object[] args)
        {
            text = (args != null ? String.Format(text, args) : text);
            TextWritten(text);
        }

        public static void WriteLine(string text, params object[] args)
        {
            text = (args != null ? String.Format(text, args) : text) + System.Environment.NewLine;
            TextWritten(text);
        }

        private static void TextWritten(string text)
        {
            if (OnWrite != null) OnWrite(null, new TextWrittenEventArgs(text));
        }
    }

    public class BaseMenuItem : IMenuItem
    {
        private List<IMenuItem> childs = new List<IMenuItem>();

        public BaseMenuItem(string text, string action, IMenuItem[] newChilds = null)
        {
            Text = text;
            Action = action;
            if (newChilds != null)
            {
                foreach (IMenuItem bm in newChilds)
                    childs.Add(bm);
            }
        }

        public IMenuItem Parent { get; set; }

        public void AddChild(string descricao, string action)
        {
            childs.Add(new BaseMenuItem(descricao, action));
        }

        public void AddChild(BaseMenuItem menuItem)
        {
            childs.Add(menuItem);
        }

        public IMenuItem[] Childs
        {
            get
            {
                return childs.ToArray();
            }
        }

        public IMenuItem Root
        {
            get
            {
                IMenuItem r = this.Parent;
                while (r.Parent != null)
                    r = r.Parent;
                return r;
            }
        }

        public string Text { get; set; }
        public string Action { get; set; }
    }

    public interface IMenuItem
    {
        IMenuItem Parent { get; set; }
        IMenuItem[] Childs { get; }
        IMenuItem Root { get; }
        string Text { get; set; }
        string Action { get; set; }
        void AddChild(string descricao, string action);
        void AddChild(BaseMenuItem menuItem);
    }

    public static class PSHelpers
    {
        public static HtmlString ImportXml()
        {
            //        if (!System.IO.File.Exists("d:\\meusprodutos.xml"))
            //            return new HtmlString("");

            //        ProSoft.Model m = new ProSoft.Model();
            //        m.ExecuteStoreCommand("delete from Grupo");
            //        m.ExecuteStoreCommand("delete from Produto");

            //        m = new ProSoft.Model();

            //        XDocument xmlDoc = XDocument.Load("d:\\meusprodutos.xml"); 
            ////        System.IO.File.Delete("d:\\meusprodutos.xml");
            //        
            //        //StringBuilder sb = new StringBuilder();
            //        var grg = xmlDoc.Descendants("Export").Descendants("Grupos").Descendants("Grupo");

            //        System.Func<string, long?> ParseLong = (text) =>
            //        {
            //            if (string.IsNullOrEmpty(text))
            //                return null;
            //            else
            //                return (long?)long.Parse(text);
            //        };

            //        // importa todos os grupos como raiz
            //        var grupos = from c in grg
            //                select new GrupoImport
            //                {
            //                    GrupoId = long.Parse(c.Element("GrupoId").Value),
            //                    Descricao = c.Element("Descricao").Value,
            //                    ParentId = ParseLong(c.Element("ParentId").Value)
            //                };

            //        List<ProSoft.Grupo> gruposl = new List<ProSoft.Grupo>();
            //        foreach (GrupoImport c in grupos)
            //        {
            //            ProSoft.Grupo parent = null;
            //            if (c.ParentId != null)
            //            {
            //                parent = gruposl.FirstOrDefault(k)
            //            }

            //            gruposl.Add(
            //            new ProSoft.Grupo
            //            {
            //            });
            //            if (c.ParentId != null)
            //            {

            //            }
            //        }

            //        foreach (var g in grupos)
            //            m.Grupos.AddObject(g);

            //        foreach (var g in grg)
            //        {
            //            if (!string.IsNullOrEmpty(g.Element("Descricao").Value))
            //            {
            //                long? ParentId = ParseLong(g.Element("ParentId").Value);
            //                long? GrupoId = ParseLong(g.Element("GrupoId").Value);
            //                if (ParentId != null && GrupoId != null)
            //                {
            //                    ProSoft.Grupo parent = m.Grupos.FirstOrDefault(k=>k.GrupoId == ParentId);

            //                    ProSoft.Grupo thisgrupo = m.Grupos.FirstOrDefault(k=>k.GrupoId == GrupoId);

            //                    thisgrupo.Parent = parent;
            //                }
            //            }
            //        }

            //        m.SaveChanges();

            //        var produtos = from c in xmlDoc.Descendants("Export").Descendants("Produtos").Descendants("Produto")
            //            select new ProSoft.Produto
            //            {
            //                   ProdutoId = long.Parse(c.Element("ProdutoId").Value),
            //                   Descricao = c.Element("Descricao").Value,
            //                   Unidade = c.Element("Unidade").Value,
            //                   Unitario = double.Parse(c.Element("Unitario").Value),
            //                   GrupoId = ParseLong(c.Element("GrupoId").Value),
            //                   Imagem = c.Element("Imagem").Value
            //            };

            //        foreach(var p in produtos)
            //            m.Produtos.AddObject(p);
            //        m.SaveChanges();

            return new HtmlString("");
        }

        public static HtmlString StartOverlay(string overlayId)
        {
            StringBuilder html = new StringBuilder();

            html.Append(string.Format("<div id=\"%1\" style=\"display: none; position: fixed; left: 0; top: 0; width: 100%; height: 100%; z-index: 1000\">", overlayId));
            html.Append("<table border=\"0\" style=\"padding: 0; margin: 0; width: 100%; height: 100%; border-spacing: 0; border-style: none\">");
            html.Append("<tr>");
            html.Append(string.Format("<td class=\"transparent\" style=\"height: auto; width: auto\" onclick=\"return toggleOverlay('%1')\"></td>", overlayId));
            html.Append(string.Format("<td class=\"transparent\" style=\"height: auto; width: auto\" onclick=\"return toggleOverlay('%1')\"></td>", overlayId));
            html.Append(string.Format("<td class=\"transparent\" style=\"height: auto; width: auto\" onclick=\"return toggleOverlay('%1')\"></td>", overlayId));
            html.Append("</tr>");
            html.Append("<tr>");
            html.Append(string.Format("<td class=\"transparent\" style=\"width: auto\" onclick=\"return toggleOverlay('%1')\"></td>", overlayId));
            html.Append(string.Format("<td class=\"opaque\" style=\"text-align: center; vertical-align: middle; width: 300px; height: 200px; margin: 0; padding: 0\">"));

            return new HtmlString(html.ToString());
        }

        public static HtmlString EndOverlay(string idOverlay)
        {
            StringBuilder html = new StringBuilder();

            html.Append("</td>");
            html.Append(string.Format("<td class=\"transparent\" style=\"width: auto\" onclick=\"return toggleOverlay('%1')\" ></td>", idOverlay));
            html.Append("</tr>");
            html.Append("<tr>");
            html.Append(string.Format("<td class=\"transparent\" style=\"height: auto; width: auto\" onclick=\"return toggleOverlay('%1')\">", idOverlay));
            html.Append("</td>");
            html.Append(string.Format("<td class=\"transparent\" style=\"height: auto; width: auto\" onclick=\"return toggleOverlay('%1')\"></td>", idOverlay));
            html.Append(string.Format("<td class=\"transparent\" style=\"height: auto; width: auto\" onclick=\"return toggleOverlay('%1')\"></td>", idOverlay));
            html.Append("</tr>");
            html.Append("</table>");
            html.Append("</div>");

            return new HtmlString(html.ToString());
        }

        public static HtmlString StartWindow(string title, string width = "100%", string captionHeight = "45px", string borderWidth = "20px", string _class = null)
        {
            //HtmlTable table = new HtmlTable();
            //
            //table.Style.Add("border-style", "none");
            //table.Style.Add("padding","0px");        
            //table.Width = width;
            //table.Border = 0;
            //table.CellSpacing = 0;
            //table.CellPadding = 0;

            //if (_class != null)
            //    table.Style.Class = _class;

            //HtmlTableRow row = new HtmlTableRow();
            //row.Style.Add("border-style", "none");
            //row.Style.Add("padding", "none");
            //row.Style.Add("width", "none");
            //row.Style.Add("min-width", "none");
            //row.Style.Add("max-width", "none");
            //row.Style.Add("height", "none");
            //row.Style.Add("min-height", "none");
            //row.Style.Add("max-height", "none");
            //row.Style.Add("", "none");
            //row.Style.Add("", "none");


            StringBuilder html = new StringBuilder();
            if (_class == null)
            {
                html.AppendFormat("<table style=\"border-style:none; padding:0px\" width=\"{0}\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\"", width);
            }
            else
            {
                html.AppendFormat("<table style=\"border-style:none; padding:0px\" width=\"{0}\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\" class=\"@_class\">", width);
            }
            html.Append("<tr>");
            html.Append("<td style=\"border-style: none; padding:0; width:20px; min-width:20px; max-width:20px; height:45px; min-height:45px; max-height:45px; background-image:url('/Images/window_lt.jpg'); background-repeat: no-repeat\">");
            html.AppendFormat("<td style=\"border-style: none; padding:0; width:auto; height:45px; min-height:45px; max-height:45px; background-image:url('/Images/window_t.jpg'); padding-left:10px\">{0}</td>", title);
            html.Append("<td style=\"border-style: none; padding:0; width:20px; min-width:20px; max-width:20px; height:45px; min-height:45px; max-height:45px; background-image:url('/Images/window_rt.jpg'); background-repeat: no-repeat\"></td>");
            html.Append("</tr>");

            html.Append("<tr style=\"height: 100px\">");
            html.Append("<td style=\"border-style: none; padding:0; background-image: url('/Images/Window_l.jpg')\"></td>");
            html.Append("<td style=\"border-style:none\" valign=\"top\">");
            return new HtmlString(html.ToString());
        }

        public static HtmlString EndWindow()
        {
            StringBuilder html = new StringBuilder();
            html.Append("</td>");
            html.Append("<td style=\"border-style: none; padding:0; background-image: url('/Images/Window_r.jpg')\"></td>");
            html.Append("</tr>");
            html.Append("<tr style=\"border-style: none; padding:0; height: 20px\">");
            html.Append("<td style=\"border-style: none; padding:0; height:20px; background-image: url('/Images/Window_lb.jpg'); background-repeat: no-repeat;\"></td>");
            html.Append("<td style=\"border-style: none; padding:0; height:20px; background-image: url('/Images/Window_b.jpg')\"></td>");
            html.Append("<td style=\"border-style: none; padding:0; height:20px; background-image: url('/Images/Window_rb.jpg'); background-repeat: no-repeat;\"></td>");
            html.Append("</tr>");
            html.Append("</table>");
            return new HtmlString(html.ToString());
        }

        public static HtmlString DrawVerticalMenu(IMenuItem[] rootItems, string width = "100px")
        {
            string style = "style=\"";
            style += "width:" + width;
            style += "; left:" + width;
            style += "\"";

            StringBuilder html = new StringBuilder();
            html.Append("<div id=\"verticalmenu\">");
            html.AppendFormat("<ul id=\"menuList\" style=\"width:{0}\">", width);

            System.Action<IMenuItem> drawItem = null;
            drawItem = (item) =>
            {
                string href = "Default";
                if (!string.IsNullOrEmpty(item.Action))
                    href = item.Action;

                html.AppendFormat("<li><a href=\"{1}\">{0}</a>", item.Text, href);

                if (item.Childs.Length > 0)
                {
                    html.AppendFormat("<ul id=\"menuList\" {0}>", style);

                    foreach (IMenuItem imi in item.Childs)
                        drawItem(imi);

                    html.Append("</ul>");
                }

                html.Append("</li>");
            };

            foreach (IMenuItem itm in rootItems)
                drawItem(itm);

            //if (rootItem.Childs.Length > 0) 
            //{
            //    html.AppendFormat("<ul id=\"menuList\" {0}>", width);
            //        html.Append("<li><a href=\"Default\">Início</a></li>");
            //    html.Append("</ul>");
            //}

            html.Append("</ul></div>");
            return new HtmlString(html.ToString());
        }

        //private static HtmlString DrawChilds(IMenuItem item)
        //{
        //    HtmlString 
        //    
        //    @:<ul id="menuList">
        //    foreach (IMenuItem im in item.Childs)
        //    {
        //        @:<li><a href="Default">xxxxxx</a></li>
        //    }
        //    @:</ul>
        //}

        public static void ShowMessage(string message, string overlayId = "messageOverlay")
        {
            if (!string.IsNullOrEmpty(message))
            {
                StartOverlay(overlayId);
                StartWindow("Mensagem");

                StringBuilder html = new StringBuilder();

                html.Append("<p style=\"text_align: center; width: 100%\">" + message + ".</p>");
                html.Append("<div style=\"text_align: center\"><input type=\"button\" value=\"Ok\"/></div>");

                EndWindow();
                EndOverlay(overlayId);
            }
        }

    }

    public static class ExtensoHelpers
    {
        //public static bool IsEmpty(this string aString)
        //{
        //    return string.IsNullOrEmpty(aString);
        //}

        //public static string AddMask(this string astring, string mask)
        //{
        //    if (astring.IsEmpty())
        //        return null;
        //    if (mask.IsEmpty())
        //        return astring;
        //    System.ComponentModel.MaskedTextProvider provider = new System.ComponentModel.MaskedTextProvider(mask, System.Globalization.CultureInfo.InvariantCulture);
        //    provider.Set(astring);
        //    return provider.ToDisplayString();
        //}

        //public static string RemoveMask(this string astring, string mask)
        //{
        //    if (astring.IsEmpty())
        //        return null;
        //    if (mask.IsEmpty())
        //        return astring;
        //    System.ComponentModel.MaskedTextProvider provider = new System.ComponentModel.MaskedTextProvider(mask, System.Globalization.CultureInfo.InvariantCulture);
        //    provider.Set(astring);
        //    provider.IncludeLiterals = false;
        //    return provider.ToString(false, false, false, 0, astring.Length);
        //}

        /// <summary>
        /// Informa se um string é a representação válida de um int;
        /// </summary>
        public static bool IsInt(this string text)
        {
            int i = 0;
            return int.TryParse(text, out i);
        }

        /// <summary>
        ///Retorna true se um string contem somente digitos.
        ///Vazio ou nulo é considerado como verdadeiro
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static bool IsDigits(this string text)
        {
            if (string.IsNullOrEmpty(text))
                return true;

            foreach (char c in text)
            {
                if (!c.IsDigit())
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Informa se um string é a representação válida de um float.
        /// </summary>
        public static bool IsFloat(this string text)
        {
            float i = 0;
            return float.TryParse(text, out i);
        }
        /// <summary>
        /// Informa se um <seealso cref="char"/> é a representação de um dígito.
        /// </summary>
        public static bool IsDigit(this char key)
        {
            int i = 0;
            return int.TryParse(key.ToString(), out i);
        }

        public static string ToMoedaExt(this double value, bool acompanhaExtensoEntreParenteses = true)
        {
            string s = value.ToString("C");

            if (acompanhaExtensoEntreParenteses)
            {
                s += " (" + value.ToExtenso("Real", "Reais", "centavo", "centavos") + ")";
            }

            return s;
        }

        /// <summary>
        /// Converte um número para extenso
        /// </summary>
        /// <param name="valor">O número a ser convertido</param>
        /// <param name="inteirosingular">Inteiro no singular (Ex: Real)</param>
        /// <param name="inteiroplural">Inteiro no plural (Ex: Reais)</param>
        /// <param name="quebradosingular">Fração no singular (Ex: Centavo)</param>
        /// <param name="quebradoplural">Fração no plural (Ex: Centavos)</param>
        /// <param name="feminino">O texto retornado será em feminino?</param>
        /// <returns>Uma string que representa o número "valor" em extenso</returns>
        public static string ToExtenso(this int valor, string inteirosingular = "", string inteiroplural = "", string quebradosingular = "", string quebradoplural = "", bool feminino = false)
        {
            double d = (double)valor;
            return d.ToExtenso(inteirosingular, inteiroplural, quebradosingular, quebradoplural, feminino);
        }

        /// <summary>
        /// Converte um número para extenso
        /// </summary>
        /// <param name="valor">O número a ser convertido</param>
        /// <param name="inteirosingular">Inteiro no singular (Ex: Real)</param>
        /// <param name="inteiroplural">Inteiro no plural (Ex: Reais)</param>
        /// <param name="quebradosingular">Fração no singular (Ex: Centavo)</param>
        /// <param name="quebradoplural">Fração no plural (Ex: Centavos)</param>
        /// <param name="feminino">O número é feminino?</param>
        /// <returns>Uma string que representa o número "valor" em extenso</returns>
        public static string ToExtenso(this float valor, string inteirosingular = "", string inteiroplural = "", string quebradosingular = "", string quebradoplural = "", bool feminino = false)
        {
            double d = (double)valor;
            return d.ToExtenso(inteirosingular, inteiroplural, quebradosingular, quebradoplural, feminino);
        }

        /// <summary>
        /// Retorna o valor em extenso e em ordinal.
        /// </summary>
        /// <param name="valor">Valor a ser convertido.</param>
        /// <param name="feminino">O número é feminino?</param>
        /// <returns>String representando o valor em ordinal.</returns>
        public static string ExtensoOrdinal(this int valor, bool feminino = false)
        {
            return ((double)valor).ToExtensoOrdinal(feminino);
        }
        /// <summary>
        /// Retorna o valor em extenso e em ordinal.
        /// </summary>
        /// <param name="valor">Valor a ser convertido.</param>
        /// <param name="feminino">O número é feminino?</param>
        /// <returns>String representando o valor em ordinal.</returns>
        public static string ToExtensoOrdinal(this double valor, bool feminino = false)
        {
            string texto = "";
            string[] Unidades = { "", "Primeiro ", "Segundo ", "Terceiro  ", "Quarto", "Quinto ", "Sexto ", "Sétimo ", "Oitavo ", "Nono " };
            string[] Dezenas = { "", "Décimo ", "Vigésimo ", "Trigésimo ", "Quadragésimo ", "Quinquagésimo ", "Sexagésimo ", "Setuagésimo ", "Octogésimo ", "Novagésimo " };
            string[] Centenas = { "", "Centésimo ", "Ducentésimo ", "Tricentésimo ", "Quadringentésimo ", "Quingentésimo ", "Sexcentésimo ", "Septingentésimo ", "Octingentésimo ", "Noningentésimo " };
            if (feminino)
            {
                Unidades = new string[] { "", "Primeira ", "Segunda ", "Terceira  ", "Quarta", "Quinta ", "Sexta ", "Sétima ", "Oitava ", "Nono " };
                Dezenas = new string[] { "", "Décima ", "Vigésima ", "Trigésima ", "Quadragésima ", "Quinquagésima ", "Sexagésima ", "Setuagésima ", "Octogésima ", "Novagésima " };
                Centenas = new string[] { "", "Centésima ", "Ducentésima ", "Tricentésima ", "Quadringentésima ", "Quingentésima ", "Sexcentésima ", "Septingentésima ", "Octingentésima ", "Noningentésima " };
            }

            // tira os possiveis espacos em branco.
            string numero = valor.ToString().Trim();
            // cria um laço para caminhar na string da direita para esquerda pegando os numeros.
            for (int conta = numero.Length - 1; conta > -1; conta--)
            {
                string txnum = numero.Substring(conta, 1);
                int num = 0;
                int.TryParse(txnum, out num);

                // unidades
                if (numero.Length - conta == 1) texto = Unidades[num];
                // dezenas
                if (numero.Length - conta == 2) texto = Dezenas[num] + texto;
                // centenas
                if (numero.Length - conta == 3) texto = Centenas[num] + texto;
                // milhares
                if (numero.Length - conta > 3) texto = "nao sabe contar tanto,ainda." + texto;
            }
            return texto.Trim().ToLower();
        }

        /// <summary>
        /// Converte um número para extenso
        /// </summary>
        /// <param name="valor">O número a ser convertido</param>
        /// <param name="inteirosingular">Inteiro no singular (Ex: Real)</param>
        /// <param name="inteiroplural">Inteiro no plural (Ex: Reais)</param>
        /// <param name="quebradosingular">Fração no singular (Ex: Centavo)</param>
        /// <param name="quebradoplural">Fração no plural (Ex: Centavos)</param>
        /// <param name="feminino">O valor retornado será em feminino?</param>
        /// <returns>Uma string que representa o número "valor" em extenso</returns>
        public static string ToExtenso(this double valor, string inteirosingular = "", string inteiroplural = "", string quebradosingular = "", string quebradoplural = "", bool feminino = false)
        {
            bool negativo = false;
            if (valor < 0)
            {
                negativo = true;
                valor *= -1;
            }

            string wvalor = valor.ToString("N2");
            if (!string.IsNullOrEmpty(inteirosingular))
                inteirosingular = " " + inteirosingular;
            if (!string.IsNullOrEmpty(inteiroplural))
                inteiroplural = " " + inteiroplural;
            if (!string.IsNullOrEmpty(quebradosingular))
                quebradosingular = " " + quebradosingular;
            if (!string.IsNullOrEmpty(quebradoplural))
                quebradoplural = " " + quebradoplural;

            string[] wunidade = { "", " e um", " e dois", " e três", " e quatro", " e cinco", " e seis", " e sete", " e oito", " e nove" };

            if (feminino)
            {
                wunidade[1] = " e uma";
                wunidade[2] = " e duas";
            }

            string[] wdezes = { "", " e onze", " e doze", " e treze", " e quatorze", " e quinze", " e dezesseis", " e dezessete", " e dezoito", " e dezenove" };
            string[] wdezenas = { "", " e dez", " e vinte", " e trinta", " e quarenta", " e cinquenta", " e sessenta", " e setenta", " e oitenta", " e noventa" };
            string[] wcentenas = { "", " e cento", " e duzentos", " e trezentos", " e quatrocentos", " e quinhentos", " e seiscentos", " e setecentos", " e oitocentos", " e novecentos" };
            string[] wplural = { " bilhões", " milhões", " mil", "" };
            string[] wsingular = { " bilhão", " milhão", " mil", "" };
            string wextenso = "";
            string wfracao;
            wvalor = wvalor.Replace("R$", "").Trim();
            string wnumero = wvalor.Replace(",", "").Trim();
            wnumero = wnumero.Replace(".", "").PadLeft(14, '0');

            if (Int64.Parse(wnumero.Substring(0, 12)) > 0)
            {
                for (int i = 0; i < 4; i++)
                {
                    wfracao = wnumero.Substring(i * 3, 3);
                    if (int.Parse(wfracao) != 0)
                    {
                        if (int.Parse(wfracao.Substring(0, 3)) == 100)
                            wextenso += " e cem";
                        else
                        {
                            wextenso += wcentenas[int.Parse(wfracao.Substring(0, 1))];
                            if (int.Parse(wfracao.Substring(1, 2)) > 10 && int.Parse(wfracao.Substring(1, 2)) < 20)
                                wextenso += wdezes[int.Parse(wfracao.Substring(2, 1))];
                            else
                            {
                                wextenso += wdezenas[int.Parse(wfracao.Substring(1, 1))];
                                wextenso += wunidade[int.Parse(wfracao.Substring(2, 1))];
                            }
                        }
                        if (int.Parse(wfracao) > 1)
                            wextenso += wplural[i];
                        else
                            wextenso += wsingular[i];
                    }
                }
                if (Int64.Parse(wnumero.Substring(0, 12)) > 1)
                    wextenso += inteiroplural;
                else
                    wextenso += inteirosingular;
            }
            wfracao = wnumero.Substring(12, 2);
            if (int.Parse(wfracao) > 0)
            {
                if (int.Parse(wfracao.Substring(0, 2)) > 10 && int.Parse(wfracao.Substring(0, 2)) < 20)
                    wextenso = wextenso + wdezes[int.Parse(wfracao.Substring(1, 1))];
                else
                {
                    wextenso += wdezenas[int.Parse(wfracao.Substring(0, 1))];
                    wextenso += wunidade[int.Parse(wfracao.Substring(1, 1))];
                }
                if (int.Parse(wfracao) > 1)
                    wextenso += quebradoplural;
                else
                    wextenso += quebradosingular;
            }
            if (wextenso != "")
            {
                wextenso = wextenso.Substring(3, 1) + wextenso.Substring(4);
            }
            else
                wextenso = "Nada";
            return wextenso + (negativo ? " negativo" : "");
        }
    }

    public static class DateTimeHelpers
    {
        ///// <summary>
        ///// Diferença em meses, entre duas datas
        ///// </summary>
        ///// <returns>O número de meses</returns>
        //public static int DiffMonths(this DateTime startDate, DateTime endDate)
        //{
        //    int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
        //    return Math.Abs(monthsApart);
        //}
        ///// <summary>
        ///// Diferença em dias, entre duas datas
        ///// </summary>
        ///// <returns>O número de dias</returns>
        //public static long DiffDays(this DateTime startDate, DateTime endDate)
        //{
        //    return (long)(endDate - startDate).TotalDays;
        //}
        ///// <summary>
        ///// Diferença em anos, entre duas datas
        ///// </summary>
        ///// <returns>O número de anos</returns>
        //public static int DiffYears(this DateTime startDate, DateTime endDate)
        //{
        //    // get the difference in years
        //    int years = endDate.Year - startDate.Year;
        //    // subtract another year if we're before the birth day in the current year
        //    if (endDate.Month < startDate.Month || (endDate.Month == startDate.Month && endDate.Day < startDate.Day))
        //        --years;
        //    return years;
        //}
        ///// <summary>
        ///// Retorna a diferença entre duas datas, em dias, meses e anos
        ///// </summary>
        //public static void Diff(this DateTime startDate, DateTime endDate, out int years, out int months, out int days)
        //{
        //    years = startDate.DiffYears(endDate);
        //    months = endDate.Month - startDate.Month;
        //    if (startDate.Day > endDate.Day)
        //        --months;
        //    if (months < 0) months = 0;
        //    days = endDate.Day - startDate.Day;
        //    if (days < 0) days = 0;
        //}
        ///// <summary>
        ///// Retorna novo DateTime no mesmo dia do mês, mas acrescido do número de meses passados, que pode ser negativo.
        ///// </summary>
        //public static DateTime AddMonths(this DateTime dateTime, int count)
        //{
        //    int y = dateTime.Year + (count / 12);
        //    int m = dateTime.Month + (count % 12);
        //    return new DateTime(y, m, dateTime.Day);
        //}
        ///// <summary>
        ///// Retorna um novo DateTime, no mesmo dia do ano e no mesmo mês, mas acrescido do número de dias passado, que pode ser negativo.
        ///// </summary>
        //public static DateTime AddYears(this DateTime dateTime, int count)
        //{
        //    int y = dateTime.Year + count;
        //    return new DateTime(y, dateTime.Month, dateTime.Day);
        //}

        public static int Idade(this DateTime nascimento)
        {
            DateTime curDate = DateTime.Today;
            DateTime testDate = new DateTime(curDate.Year, nascimento.Month, nascimento.Day);
            int Age = curDate.Year - nascimento.Year;
            // Overloaded comparision operator
            if (testDate <= curDate) // You do not yet celebrate your birthday this year
            {
                Age--;
            }
            return Age;
        }

        ///// <summary>
        ///// Retorna quantos anos, meses e dias tem um timespan.
        ///// </summary>
        ///// <param name="timeSpan"></param>
        ///// <param name="years"></param>
        ///// <param name="months"></param>
        ///// <param name="days"></param>
        //public static void Decompose(this TimeSpan timeSpan, out int years, out int months, out int days)
        //{
        //    DateTime dt = DateTime.MinValue + timeSpan;

        //    // note: MinValue is 1/1/1 so we have to subtract...
        //    years = dt.Year - 1;
        //    months = dt.Month - 1;
        //    days = dt.Day - 1;
        //}

        //public static void DateDiff(DateTime dtStart, DateTime dtEnd, out int Years, out int Months, out int Days, out int Hours, out int Minutes, out int Seconds)
        //{
        //    TimeSpan TS = dtEnd - dtStart;

        //    Years = dtEnd.Year - dtStart.Year;
        //    Months = dtEnd.Month - dtStart.Month;
        //    Days = dtEnd.Day - dtStart.Day;
        //    Hours = dtEnd.Hour - dtStart.Hour;
        //    Minutes = dtEnd.Minute - dtStart.Minute;
        //    Seconds = dtEnd.Second - dtStart.Second;

        //    //if (intYears > 0) return String.Format("há {0} {1}", intYears, (intYears == 1) ? "ano" : "anos");
        //    //else if (intMonths > 0) return String.Format("há {0} {1}", intMonths, (intMonths == 1) ? "mês" : "meses");
        //    //else if (intDays > 0) return String.Format("há {0} {1}", intDays, (intDays == 1) ? "dia" : "dias");
        //    //else if (intHours > 0) return String.Format("há {0} {1}", intHours, (intHours == 1) ? "hora" : "horas");
        //    //else if (intMinutes > 0) return String.Format("há {0} {1}", intMinutes, (intMinutes == 1) ? "minuto" : "minutos");
        //    //else if (intSeconds > 0) return String.Format("há {0} {1}", intSeconds, (intSeconds == 1) ? "segundo" : "segundos");
        //    //else
        //    //{
        //    //    return String.Format("em {0} às {1}", dtStart.ToShortDateString(), dtStart.ToShortTimeString());
        //    //}
        //}

        public static TimeSpan FromYMD(this TimeSpan timespan, int years, int months, int days)
        {
            DateTime Birth = DateTime.MinValue.AddYears(years).AddMonths(months).AddDays(days);
            return Birth - DateTime.MinValue;
        }
        /// <summary>
        /// Informa se um string é a representação válida de um DateTime.
        /// </summary>
        public static bool IsDateTime(this string text)
        {
            DateTime d = DateTime.MinValue;
            return DateTime.TryParse(text, out d);
        }
        public static double ToValue(this TimeSpan ts, double valorDoMinuto)
        {
            return ts.TotalHours * (valorDoMinuto * 60f);
        }
        public static TimeSpan ToDuration(this double valor, double valorDoMinuto)
        {
            double horas = valor / (valorDoMinuto * 60f);
            if (valor == 0 || valorDoMinuto == 0)
                horas = 0;
            DateTime fim = DateTime.Now.AddHours(horas);
            return fim - DateTime.Now;
        }
        /// <summary>
        /// Remove todas as ocorrências de todos os caracteres passados em <para="ocurrences"> do string.
        /// </summary>
        /// <param name="aString"></param>
        /// <param name="ocurrences"></param>
        /// <returns>Retorna o string sem nenhum dos caracteres passados.</returns>
        public static string RemoveOcurrences(this string aString, string ocurrences)
        {
            if (string.IsNullOrEmpty(aString))
                return aString;
            else
            {
                string tx = aString;
                foreach (char c in ocurrences)
                {
                    tx = tx.Replace(new string(c, 1), "");
                }
                return tx;
            }
        }
        public static string AsString(this TimeSpan ts)
        {
            return ts.Hours.ToString().PadLeft(2, '0') + ":" + ts.Minutes.ToString().PadLeft(2, '0') + ":" + ts.Seconds.ToString().PadLeft(2, '0');
        }
        /// <summary>
        /// Converte uma data/hora para extenso, inclusive número do dia e do ano
        /// </summary>
        /// <param name="dt">O datetime que será convertido</param>
        /// <param name="returnDate">Retorna a data?</param>
        /// <param name="returnTime">Retorna a hora?</param>
        /// <param name="includenumbers">Incluir números de dia, ano e hora?</param>
        /// <param name="diaEAnoEmExtenso">Dia e ano serão representados por extenso?</param>
        /// <param name="timeExtenso">HOra será representada por extenso?</param>
        /// <param name="feminino">Ordinais serão representados em feminino?</param>
        /// <param name="primeiroDiaOrdinal">O primeiro dia do mês será representado em ordinal?</param>
        /// <param name="todosDiasOrdinal">Os dias serão representados em ordinal?</param>
        /// <returns>Um string que é a representação por extenso da data</returns>
        public static string ToExtenso(this System.DateTime? dt, bool returnDate = true, bool returnTime = false, bool includenumbers = false, bool diaEAnoEmExtenso = true, bool timeExtenso = false, bool feminino = false, bool primeiroDiaOrdinal = false, bool todosDiasOrdinal = false)
        {
            if (dt != null)
                return ((DateTime)dt).ToExtenso(returnDate, returnTime, includenumbers, diaEAnoEmExtenso, timeExtenso, feminino, primeiroDiaOrdinal, todosDiasOrdinal);
            else
                return "";
        }
        /// <summary>
        /// Converte um número inteiro em nome do mês que ele representa [1..12].
        /// </summary>
        /// <param name="numero">Número do mês.</param>
        /// <returns>O nome do mês</returns>
        public static string ToMonthName(this int numeroMes)
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("pt-BR");
            System.Globalization.DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            return dtfi.GetMonthName(numeroMes);
        }
        /// <summary>
        /// Converte um número inteiro em nome do mês que ele representa [1..12].
        /// </summary>
        /// <param name="numero">Número do mês.</param>
        /// <returns>O nome do mês</returns>
        public static string Mes(this DateTime date)
        {
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("pt-BR");
            System.Globalization.DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            return dtfi.GetMonthName(date.Month);
        }
        /// <summary>
        /// Converte uma data/hora para extenso, inclusive número do dia e do ano
        /// </summary>
        /// <param name="dt">O datetime que será convertido</param>
        /// <param name="returnDate">Retorna a data?</param>
        /// <param name="returnTime">Retorna a hora?</param>
        /// <param name="includenumbers">Incluir números de dia, ano e hora?</param>
        /// <param name="diaEAnoEmExtenso">Dia e ano serão representados por extenso?</param>
        /// <param name="timeExtenso">HOra será representada por extenso?</param>
        /// <param name="feminino">Ordinais serão representados em feminino?</param>
        /// <param name="primeiroDiaOrdinal">O primeiro dia do mês será representado em ordinal?</param>
        /// <param name="todosDiasOrdinal">Os dias serão representados em ordinal?</param>
        /// <returns>Um string que é a representação por extenso da data</returns>
        public static string ToExtenso(this DateTime dt, bool returnDate = true, bool returnTime = false, bool includenumbers = false, bool diaEAnoEmExtenso = false, bool timeExtenso = false, bool feminino = false, bool primeiroDiaOrdinal = false, bool todosDiasOrdinal = false)
        {
            //System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("pt-BR");
            //System.Globalization.DateTimeFormatInfo dtfi = culture.DateTimeFormat;        
            int dia = dt.Day;
            int ano = dt.Year;
            string mes = dt.Month.ToMonthName();// dtfi.GetMonthName(dt.Month);
            string hora = "";
            string data = "";
            string ret = "";
            if (returnTime)
            {
                if (timeExtenso)
                {
                    string hr = "";
                    string mr = "";
                    if (dt.Hour > 0)
                        hr = dt.Hour.ToExtenso("hora", "horas", "", "", true);
                    if (dt.Minute > 0)
                        mr = dt.Minute.ToExtenso("minuto", "minutos", "", "", false);
                    if (hr.Length > 0 && mr.Length > 0)
                        hora = hr + " e " + mr;
                    else
                        hora = hr + mr;
                    if (includenumbers) hora += " (";
                }
                if (!timeExtenso || includenumbers)
                {
                    string hr = "h";
                    string min = "min";
                    hora += dt.Hour.ToString().PadLeft(2, '0');
                    if (dt.Minute > 0)
                        hora += hr + dt.Minute.ToString().PadLeft(2, '0') + min;
                    else
                        hora += "horas";
                }
                if (includenumbers) hora += ")";
            }
            if (returnDate)
            {
                string dn = "";
                string yn = "";
                if (includenumbers)
                {
                    if (primeiroDiaOrdinal && dia == 1)
                        dn = "(1º)";
                    else if (todosDiasOrdinal)
                        dn = " (" + dia.ToString() + "º)";
                    else
                        dn = " (" + dia.ToString().PadLeft(2, '0') + ")";
                    yn = " (" + ano.ToString() + ")";
                }
                string diae = dia.ToString();
                string anoe = ano.ToString();
                if (diaEAnoEmExtenso)
                {
                    if (primeiroDiaOrdinal && dia == 1)
                        diae = "primeiro";
                    else if (todosDiasOrdinal)
                        diae = dia.ExtensoOrdinal();
                    else
                        diae = dia.ToExtenso("", "", "", "", false);
                    anoe = ano.ToExtenso();
                }
                string doano = diaEAnoEmExtenso ? " de " : " de ";
                data += diae + dn + " de " + mes + doano + anoe + yn;
            }
            if (hora.Length > 0 && data.Length > 0)
                ret = hora + " do dia " + data;
            else
                ret = hora + data;
            return ret;
        }
    }

};
