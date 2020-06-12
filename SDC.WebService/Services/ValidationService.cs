using Microsoft.Extensions.Logging;
using SDC.WebService.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Xml;
using System.Xml.Schema;

namespace SDC.WebService.Services
{
    public class ValidationService : IValidationService
    {
        private readonly ILogger<ValidationService> _logger;
        private List<string> _xsdFullPathFileNames;
        private List<string> _xsdFileNames = new List<string> {
            "SDCFormDesign.xsd",
            "SDCBase.xsd",
            "SDCDataTypes.xsd",
            "SDCExpressions.xsd",
            "SDCResources.xsd"
        };

        public ValidationService(ILogger<ValidationService> logger)
        {
            _logger = logger;
            InitializeXsdPaths();
        }

        public StatusInfo ValidateXml(string xmlFile)
        {
            using var xmlFileStream = new MemoryStream(Encoding.UTF8.GetBytes(xmlFile ?? ""));
            try
            {
                var settings = new XmlReaderSettings
                {
                    ValidationType = ValidationType.Schema
                };

                XmlDocument document = new XmlDocument();
                AddXsdsToSchema(document);

                document.Load(xmlFileStream);
                document.Validate(new ValidationEventHandler(ValidationEventHandler));

                return new StatusInfo(true, new List<string>());
            }
            catch (Exception ex)
            {
                return new StatusInfo(false, new List<string>() { ex.Message});
            }
        }
        private void ValidationEventHandler(object sender, ValidationEventArgs e)
        {
            switch (e.Severity)
            {
                case XmlSeverityType.Error:
                    _logger.LogError(e.Message);
                    throw new Exception(e.Message, e.Exception);
                case XmlSeverityType.Warning:
                    _logger.LogWarning(e.Message);
                    break;
            }
        }

        private void InitializeXsdPaths()
        {
            try
            {
                var buildDirectory = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
                    + Environment.GetEnvironmentVariable("XSD_FILE_DIRECTORY");

                DirectoryInfo directory = new DirectoryInfo(buildDirectory);

                _xsdFullPathFileNames = directory.GetFiles("*.xsd")
                    .Where(i => _xsdFileNames.Any(j => j == i.Name))
                    .Select(i => i.FullName)
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
        }

        private void AddXsdsToSchema(XmlDocument document)
        {
            foreach (var xsd in _xsdFullPathFileNames)
            {
                document.Schemas.Add(Environment.GetEnvironmentVariable("SDC_TARGET_NAMESPACE"), xsd);
            }
        }
    }
}
