using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VDS.RDF.Query;
using Entidades;
using Entidad1;
using Entidad3;
using Entidad4;

namespace Gestion.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //-------------------------------------------------------------------------------------------------------------------------------------------------
        public ActionResult Final()
        {
            var GeneralEntidadLista = new List<GeneralEntidad2>();

            SparqlRemoteEndpoint endpoint2 = new SparqlRemoteEndpoint(new Uri("http://localhost:3030/WebSemantica/sparql"));
            SparqlResultSet results = endpoint2.QueryWithResultSet("PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#>" +
               "PREFIX owl: <http://www.w3.org/2002/07/owl#>" +
               "PREFIX xsd: <http://www.w3.org/2001/XMLSchema#>" +
               "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>" +
                "PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#> " +
                "prefix data:<http://www.semanticweb.org/baneste/ontologies/2022/1/untitled-ontology-4#>" +
                "SELECT ?Vehiculo ?Modelo ?Color ?Placa ?Importado_Por ?Vendido_Por ?Precio_Venta " +
                "WHERE { " +
                "?x data:Vehiculo_Marca ?Vehiculo. " +
                "?x data:Vehiculo_Modelo ?Modelo. " +
                "?x data:Vehiculo_Color ?Color. " +
                "?x data:Vehiculo_Placa ?Placa. " +
                "?x data:Importado_Por ?Importado_Por. " +
                "?x data:Vendido_Por ?Vendido_Por. " +
                "?x data:Vehiculo_Precio ?Precio_Venta " +
                "}LIMIT 5 "
               );

            foreach (SparqlResult result in results)
            {
                Console.WriteLine(result.ToString());
            }
            //tomar columnas
            GeneralEntidad2 o = new GeneralEntidad2();
            var li1 = results.Variables;
            foreach (string s in li1)
            {
            }
            //tomar registros
            var li2 = results.Results;
            foreach (var s in li2)
            {
                GeneralEntidad2 on = new GeneralEntidad2();
                var lista = new List<string>();
                foreach (var resul in s)
                {
                    if (resul.Value != null)
                        lista.Add(resul.Value.ToString());
                }
                on.Vehiculo = lista[0].ToString();
                on.Modelo = lista[1].ToString();
                on.Color = lista[2].ToString();
                on.Placa = lista[3].ToString();
                on.Importado_Por = lista[4].ToString();
                on.Vendido_Por = lista[5].ToString();
                on.Precio_Venta = lista[6].ToString();
                GeneralEntidadLista.Add(on);
            }
            return View(GeneralEntidadLista);

        }

        [HttpPost]
        public ActionResult Final(string buscar)
        {
            var GeneralEntidadLista = new List<GeneralEntidad2>();

            SparqlRemoteEndpoint endpoint2 = new SparqlRemoteEndpoint(new Uri("http://localhost:3030/WebSemantica/sparql"));

            SparqlResultSet results = endpoint2.QueryWithResultSet("PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#>" +
               "PREFIX owl: <http://www.w3.org/2002/07/owl#>" +
               "PREFIX xsd: <http://www.w3.org/2001/XMLSchema#>" +
               "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>" +
                "PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#> " +
                "prefix data:<http://www.semanticweb.org/baneste/ontologies/2022/1/untitled-ontology-4#>" +
                "SELECT ?Vehiculo ?Modelo ?Color ?Placa ?Importado_Por ?Vendido_Por ?Precio_Venta " +
                "WHERE { " +
                "?x data:Vehiculo_Marca ?Vehiculo. " +
                "?x data:Vehiculo_Modelo ?Modelo. " +
                "?x data:Vehiculo_Color ?Color. " +
                "?x data:Vehiculo_Placa ?Placa. " +
                "?x data:Importado_Por ?Importado_Por. " +
                "?x data:Vendido_Por ?Vendido_Por. " +
                "?x data:Vehiculo_Precio ?Precio_Venta " +
                "FILTER(REGEX(str(?Vehiculo),'" + buscar + "','i')) } "
               );


            foreach (SparqlResult result in results)
            {
                Console.WriteLine(result.ToString());
            }
            //tomar columnas
            GeneralEntidad2 o = new GeneralEntidad2();
            var li1 = results.Variables;
            foreach (string s in li1)
            {

            }
            //tomar registros
            var li2 = results.Results;
            foreach (var s in li2)
            {
                GeneralEntidad2 on = new GeneralEntidad2();
                var lista = new List<string>();
                foreach (var resul in s)
                {
                    if (resul.Value != null)
                        lista.Add(resul.Value.ToString());

                }

                on.Vehiculo = lista[0].ToString();
                on.Modelo = lista[1].ToString();
                on.Color = lista[2].ToString();
                on.Placa = lista[3].ToString();
                on.Importado_Por = lista[4].ToString();
                on.Vendido_Por = lista[5].ToString();
                on.Precio_Venta = lista[6].ToString();
                GeneralEntidadLista.Add(on);
            }

            return View(GeneralEntidadLista);
        }


        //-----------------------------------------------------------------------------------------------------------------------------------------------
        public ActionResult Auto()
        {

            var GeneralEntidadLista = new List<GeneralEntidad1>();

            SparqlRemoteEndpoint endpoint2 = new SparqlRemoteEndpoint(new Uri("http://localhost:3030/WebSemantica/sparql"));
            string buscar2 = "";
            SparqlResultSet results = endpoint2.QueryWithResultSet("PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#>" +
               "PREFIX owl: <http://www.w3.org/2002/07/owl#>" +
               "PREFIX xsd: <http://www.w3.org/2001/XMLSchema#>" +
               "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>" +
                "PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#> " +
                "prefix data:<http://www.semanticweb.org/baneste/ontologies/2022/1/untitled-ontology-4#>" +
                "SELECT ?Vehiculo  ?Modelo ?Color ?Placa  ?Precio " +
                "WHERE { " +
                "?x data:Vehiculo_Marca ?Vehiculo. " +
                "?x data:Vehiculo_Modelo ?Modelo. " +
                "?x data:Vehiculo_Color ?Color. " +
                "?x data:Vehiculo_Placa ?Placa. " +
                "?x data:Vehiculo_Precio ?Precio " +
                "FILTER(REGEX(str(?Vehiculo),'" + buscar2 + "','i')) } LIMIT 10" 
                
               );

            foreach (SparqlResult result in results)
            {
                Console.WriteLine(result.ToString());
            }
            //tomar columnas
            GeneralEntidad1 o = new GeneralEntidad1();
            var li1 = results.Variables;
            foreach (string s in li1)
            {
            }
            //tomar registros
            var li2 = results.Results;
            foreach (var s in li2)
            {
                GeneralEntidad1 on = new GeneralEntidad1();
                var lista = new List<string>();
                foreach (var resul in s)
                {
                    if (resul.Value != null)
                        lista.Add(resul.Value.ToString());
                }
                on.Vehiculo = lista[0].ToString();
                on.Modelo = lista[1].ToString();
                on.Color = lista[2].ToString();
                on.Placa = lista[3].ToString();
                on.Precio = lista[4].ToString();
                GeneralEntidadLista.Add(on);
            }
            return View(GeneralEntidadLista);

        }
        [HttpPost]
        public ActionResult Auto(String buscar2)
        {

            var GeneralEntidadLista = new List<GeneralEntidad1>();

            SparqlRemoteEndpoint endpoint2 = new SparqlRemoteEndpoint(new Uri("http://localhost:3030/WebSemantica/sparql"));
            SparqlResultSet results = endpoint2.QueryWithResultSet("PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#>" +
               "PREFIX owl: <http://www.w3.org/2002/07/owl#>" +
               "PREFIX xsd: <http://www.w3.org/2001/XMLSchema#>" +
               "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>" +
                "PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#> " +
                "prefix data:<http://www.semanticweb.org/baneste/ontologies/2022/1/untitled-ontology-4#>" +
                "SELECT ?Vehiculo  ?Modelo ?Color ?Placa  ?Precio " +
                "WHERE { " +
                "?x data:Vehiculo_Marca ?Vehiculo. " +
                "?x data:Vehiculo_Modelo ?Modelo. " +
                "?x data:Vehiculo_Color ?Color. " +
                "?x data:Vehiculo_Placa ?Placa. " +
                "?x data:Vehiculo_Precio ?Precio " +
                "FILTER(REGEX(str(?Vehiculo),'" + buscar2 + "','i')) } "

               );

            foreach (SparqlResult result in results)
            {
                Console.WriteLine(result.ToString());
            }
            //tomar columnas
            GeneralEntidad1 o = new GeneralEntidad1();
            var li1 = results.Variables;
            foreach (string s in li1)
            {
            }
            //tomar registros
            var li2 = results.Results;
            foreach (var s in li2)
            {
                GeneralEntidad1 on = new GeneralEntidad1();
                var lista = new List<string>();
                foreach (var resul in s)
                {
                    if (resul.Value != null)
                        lista.Add(resul.Value.ToString());
                }
                on.Vehiculo = lista[0].ToString();
                on.Modelo = lista[1].ToString();
                on.Color = lista[2].ToString();
                on.Placa = lista[3].ToString();
                on.Precio = lista[4].ToString();
                GeneralEntidadLista.Add(on);
            }
            return View(GeneralEntidadLista);

        }

        
        //----------------------------------------------------------------------------------------------------------------------------------------------
        public ActionResult Cliente()
        {

            var GeneralEntidadLista = new List<GeneralEntidad3>();

            SparqlRemoteEndpoint endpoint2 = new SparqlRemoteEndpoint(new Uri("http://localhost:3030/WebSemantica/sparql"));
            SparqlResultSet results = endpoint2.QueryWithResultSet("PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#>" +
               "PREFIX owl: <http://www.w3.org/2002/07/owl#>" +
               "PREFIX xsd: <http://www.w3.org/2001/XMLSchema#>" +
               "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>" +
                "PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#> " +
                "prefix data:<http://www.semanticweb.org/baneste/ontologies/2022/1/untitled-ontology-4#>" +
                "SELECT ?Cliente ?Identificacion ?Telefono ?Email ?Edad ?Compra " +
                "WHERE { " +
                "?x data:Persona_Nombre ?Cliente. " +
                "?x data:Persona_Identificacion ?Identificacion. " +
                "?x data:Persona_Telefono ?Telefono. " +
                "?x data:Persona_Email ?Email. " +
                "?x data:Persona_Edad ?Edad. " +
                "?x data:Compra ?Compra " +
                "} LIMIT 6 "

               );

            foreach (SparqlResult result in results)
            {
                Console.WriteLine(result.ToString());
            }
            //tomar columnas
            GeneralEntidad3 o = new GeneralEntidad3();
            var li1 = results.Variables;
            foreach (string s in li1)
            {
            }
            //tomar registros
            var li2 = results.Results;
            foreach (var s in li2)
            {
                GeneralEntidad3 on = new GeneralEntidad3();
                var lista = new List<string>();
                foreach (var resul in s)
                {
                    if (resul.Value != null)
                        lista.Add(resul.Value.ToString());
                }
                on.Cliente = lista[0].ToString();
                on.Identificacion = lista[1].ToString();
                on.Telefono = lista[2].ToString();
                on.Email = lista[3].ToString();
                on.Edad = lista[4].ToString();
                on.Compra = lista[5].ToString();
                GeneralEntidadLista.Add(on);
            }
            return View(GeneralEntidadLista);

        }
        [HttpPost]
        public ActionResult Cliente(String buscar3)
        {

            var GeneralEntidadLista = new List<GeneralEntidad3>();

            SparqlRemoteEndpoint endpoint2 = new SparqlRemoteEndpoint(new Uri("http://localhost:3030/WebSemantica/sparql"));
            SparqlResultSet results = endpoint2.QueryWithResultSet("PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#>" +
               "PREFIX owl: <http://www.w3.org/2002/07/owl#>" +
               "PREFIX xsd: <http://www.w3.org/2001/XMLSchema#>" +
               "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>" +
                "PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#> " +
                "prefix data:<http://www.semanticweb.org/baneste/ontologies/2022/1/untitled-ontology-4#>" +
                "SELECT ?Cliente ?Identificacion ?Telefono ?Email ?Edad ?Compra " +
                "WHERE { " +
                "?x data:Persona_Nombre ?Cliente. " +
                "?x data:Persona_Identificacion ?Identificacion. " +
                "?x data:Persona_Telefono ?Telefono. " +
                "?x data:Persona_Email ?Email. " +
                "?x data:Persona_Edad ?Edad. " +
                "?x data:Compra ?Compra " +
                "FILTER(REGEX(str(?Cliente),'" + buscar3 + "','i')) } "
               );

            foreach (SparqlResult result in results)
            {
                Console.WriteLine(result.ToString());
            }
            //tomar columnas
            GeneralEntidad3 o = new GeneralEntidad3();
            var li1 = results.Variables;
            foreach (string s in li1)
            {
            }
            //tomar registros
            var li2 = results.Results;
            foreach (var s in li2)
            {
                GeneralEntidad3 on = new GeneralEntidad3();
                var lista = new List<string>();
                foreach (var resul in s)
                {
                    if (resul.Value != null)
                        lista.Add(resul.Value.ToString());
                }
                on.Cliente = lista[0].ToString();
                on.Identificacion = lista[1].ToString();
                on.Telefono = lista[2].ToString();
                on.Email = lista[3].ToString();
                on.Edad = lista[4].ToString();
                on.Compra = lista[5].ToString();
                GeneralEntidadLista.Add(on);
            }
            return View(GeneralEntidadLista);

        }

        //----------------------------------------------------------------------------------------------------------------------------------------------
        public ActionResult Proveedor()
        {

            var GeneralEntidadLista = new List<GeneralEntidad4>();

            SparqlRemoteEndpoint endpoint2 = new SparqlRemoteEndpoint(new Uri("http://localhost:3030/WebSemantica/sparql"));
            SparqlResultSet results = endpoint2.QueryWithResultSet("PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#>" +
               "PREFIX owl: <http://www.w3.org/2002/07/owl#>" +
               "PREFIX xsd: <http://www.w3.org/2001/XMLSchema#>" +
               "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>" +
                "PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#> " +
                "prefix data:<http://www.semanticweb.org/baneste/ontologies/2022/1/untitled-ontology-4#>" +
                "SELECT ?Proveedor  ?Nit ?Telefono ?Email ?Direccion ?Importa ?Abastece " +
                "WHERE { " +
                "?x data:Nombre_Empresa ?Proveedor. " +
                "?x data:Nit ?Nit. " +
                "?x data:Telefono ?Telefono. " +
                "?x data:Email ?Email. " +
                "?x data:Direccion ?Direccion. " +
                "?x data:Importa ?Importa." +
                "?x data:Abastece ?Abastece" +
                "} LIMIT 6 "

               );

            foreach (SparqlResult result in results)
            {
                Console.WriteLine(result.ToString());
            }
            //tomar columnas
            GeneralEntidad4 o = new GeneralEntidad4();
            var li1 = results.Variables;
            foreach (string s in li1)
            {
            }
            //tomar registros
            var li2 = results.Results;
            foreach (var s in li2)
            {
                GeneralEntidad4 on = new GeneralEntidad4();
                var lista = new List<string>();
                foreach (var resul in s)
                {
                    if (resul.Value != null)
                        lista.Add(resul.Value.ToString());
                }
                on.Proveedor = lista[0].ToString();
                on.Nit = lista[1].ToString();
                on.Telefono = lista[2].ToString();
                on.Email = lista[3].ToString();
                on.Direccion = lista[4].ToString();
                on.Importa = lista[5].ToString();
                on.Abastece = lista[6].ToString();
                GeneralEntidadLista.Add(on);
            }
            return View(GeneralEntidadLista);

        }
        [HttpPost]
        public ActionResult Proveedor(String buscar4)
        {

            var GeneralEntidadLista = new List<GeneralEntidad4>();

            SparqlRemoteEndpoint endpoint2 = new SparqlRemoteEndpoint(new Uri("http://localhost:3030/WebSemantica/sparql"));
            SparqlResultSet results = endpoint2.QueryWithResultSet("PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#>" +
              "PREFIX owl: <http://www.w3.org/2002/07/owl#>" +
              "PREFIX xsd: <http://www.w3.org/2001/XMLSchema#>" +
              "PREFIX rdf: <http://www.w3.org/1999/02/22-rdf-syntax-ns#>" +
               "PREFIX rdfs: <http://www.w3.org/2000/01/rdf-schema#> " +
               "prefix data:<http://www.semanticweb.org/baneste/ontologies/2022/1/untitled-ontology-4#>" +
               "SELECT ?Proveedor  ?Nit ?Telefono ?Email ?Direccion ?Importa ?Abastece " +
               "WHERE { " +
               "?x data:Nombre_Empresa ?Proveedor. " +
               "?x data:Nit ?Nit. " +
               "?x data:Telefono ?Telefono. " +
               "?x data:Email ?Email. " +
               "?x data:Direccion ?Direccion. " +
               "?x data:Importa ?Importa. " +
               "?x data:Abastece ?Abastece " +
              "FILTER(REGEX(str(?Proveedor),'" + buscar4 + "','i')) } "

              );

            foreach (SparqlResult result in results)
            {
                Console.WriteLine(result.ToString());
            }
            //tomar columnas
            GeneralEntidad4 o = new GeneralEntidad4();
            var li1 = results.Variables;
            foreach (string s in li1)
            {
            }
            //tomar registros
            var li2 = results.Results;
            foreach (var s in li2)
            {
                GeneralEntidad4 on = new GeneralEntidad4();
                var lista = new List<string>();
                foreach (var resul in s)
                {
                    if (resul.Value != null)
                        lista.Add(resul.Value.ToString());
                }
                on.Proveedor = lista[0].ToString();
                on.Nit = lista[1].ToString();
                on.Telefono = lista[2].ToString();
                on.Email = lista[3].ToString();
                on.Direccion = lista[4].ToString();
                on.Importa = lista[5].ToString();
                on.Abastece = lista[6].ToString();
                GeneralEntidadLista.Add(on);
            }
            return View(GeneralEntidadLista);

        }
    }
}
