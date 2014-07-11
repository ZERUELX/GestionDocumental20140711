using GestorDocument.DAL.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GestorDocument.Model.DashBoardModel;
using System.Collections.ObjectModel;
using GestorDocument.Model;

namespace TestProject1
{
    
    
    /// <summary>
    ///Se trata de una clase de prueba para DashBoardRepositoryTest y se pretende que
    ///contenga todas las pruebas unitarias DashBoardRepositoryTest.
    ///</summary>
    [TestClass()]
    public class DashBoardRepositoryTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Obtiene o establece el contexto de la prueba que proporciona
        ///la información y funcionalidad para la ejecución de pruebas actual.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Atributos de prueba adicionales
        // 
        //Puede utilizar los siguientes atributos adicionales mientras escribe sus pruebas:
        //
        //Use ClassInitialize para ejecutar código antes de ejecutar la primera prueba en la clase 
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup para ejecutar código después de haber ejecutado todas las pruebas en una clase
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize para ejecutar código antes de ejecutar cada prueba
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup para ejecutar código después de que se hayan ejecutado todas las pruebas
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///Una prueba de GetMes
        ///</summary>
        [TestMethod()]
        public void GetMesTest()
        {
            DashBoardRepository target = new DashBoardRepository(); // TODO: Inicializar en un valor adecuado
            ObservableCollection<MesModel> expected = null; // TODO: Inicializar en un valor adecuado
            ObservableCollection<MesModel> actual;
            actual = target.GetMes();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de GetAnio
        ///</summary>
        [TestMethod()]
        public void GetAnioTest()
        {
            DashBoardRepository target = new DashBoardRepository(); // TODO: Inicializar en un valor adecuado
            ObservableCollection<AnioModel> expected = null; // TODO: Inicializar en un valor adecuado
            ObservableCollection<AnioModel> actual;
            actual = target.GetAnio();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }

        /// <summary>
        ///Una prueba de GetDeterminante
        ///</summary>
        [TestMethod()]
        public void GetDeterminanteTest()
        {
            DashBoardRepository target = new DashBoardRepository(); // TODO: Inicializar en un valor adecuado
            ObservableCollection<DeterminanteModel> expected = null; // TODO: Inicializar en un valor adecuado
            ObservableCollection<DeterminanteModel> actual;
            actual = target.GetDeterminante();
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Compruebe la exactitud de este método de prueba.");
        }
    }
}
