using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using UblSharp;
using UblSharp.Generator;
using UblSharp.CommonAggregateComponents;
using UblSharp.CommonExtensionComponents;
using UblSharp.UnqualifiedDataTypes;
using UblSharp.XmlDigitalSignature;

namespace XMLtoUBL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Step 1: Install UBL.NET Library (Install-Package UblSharp)
            // Step 2: Parse the Input XML File
            XDocument xmlDoc = XDocument.Load("C:\\Users\\doguk\\OneDrive\\Desktop\\Jobs\\SoftNet\\XMLtoUBL\\XMLtoUBL\\data.xml");

            // Step 3: Map Data to UBL Objects
            var invoice = new InvoiceType
            {
                ID = xmlDoc.Root.Element("ID")?.Value ?? "1",
                IssueDate = DateTime.Parse(xmlDoc.Root.Element("IssueDate")?.Value),
                DueDate = DateTime.Parse(xmlDoc.Root.Element("DueDate")?.Value),
                AccountingSupplierParty = new SupplierPartyType
                {
                    Party = new PartyType
                    {
                        PartyName = new List<PartyNameType>
                        {
                            new PartyNameType
                            {
                                Name = xmlDoc.Root.Element("AccountingSupplyParty")?.Element("Party")?.Element("PartyName")?.Element("Name")?.Value ?? "",
                            },
                        },
                        PostalAddress = new AddressType
                        {
                            StreetName = xmlDoc.Root.Element("AccountingSupplyParty")?.Element("Party")?.Element("PostalAddress")?.Element("StreetName")?.Value ?? "",
                            CityName = xmlDoc.Root.Element("AccountingSupplyParty")?.Element("Party")?.Element("PostalAddress")?.Element("City")?.Value ?? "",
                            PostalZone = xmlDoc.Root.Element("AccountingSupplyParty")?.Element("Party")?.Element("PostalAddress")?.Element("PostalZone")?.Value ?? "",
                            Country = new CountryType
                            {
                                Name = xmlDoc.Root.Element("AccountingSupplyParty")?.Element("Party")?.Element("PostalAddress")?.Element("Country")?.Element("Name")?.Value,
                            }
                        },
                        Contact = new ContactType
                        {
                            Telephone = xmlDoc.Root.Element("AccountingSupplyParty")?.Element("Party")?.Element("Contact")?.Element("Telephone")?.Value ?? "",
                            ElectronicMail = xmlDoc.Root.Element("AccountingSupplyParty")?.Element("Party")?.Element("Contact")?.Element("Email")?.Value ?? "",
                        }
                    },
                },

                AccountingCustomerParty = new CustomerPartyType
                {
                    Party = new PartyType
                    {
                        PartyName = new List<PartyNameType> { 
                            new PartyNameType {
                                Name = xmlDoc.Root.Element("AccountingCustomerParty")?.Element("Party")?.Element("PartyName")?.Element("Name") ?.Value ?? "",
                            } 
                        },
                        PostalAddress = new AddressType
                        {
                            StreetName = xmlDoc.Root.Element("AccountingCustomerParty")?.Element("Party")?.Element("PostalAddress")?.Element("StreetName")?.Value ?? "",
                            CityName = xmlDoc.Root.Element("AccountingCustomerParty")?.Element("Party")?.Element("PostalAddress")?.Element("City")?.Value ?? "",
                            PostalZone = xmlDoc.Root.Element("AccountingCustomerParty")?.Element("Party")?.Element("PostalAddress")?.Element("PostalZone")?.Value ?? "",
                            Country = new CountryType
                            {
                                Name = xmlDoc.Root.Element("AccountingCustomerParty")?.Element("Party")?.Element("PostalAddress")?.Element("Country")?.Element("Name")?.Value,
                            }
                        },
                        Contact = new ContactType
                        {
                            Telephone = xmlDoc.Root.Element("AccountingCustomerParty")?.Element("Party")?.Element("Contact")?.Element("Telephone")?.Value ?? "",
                            ElectronicMail = xmlDoc.Root.Element("AccountingCustomerParty")?.Element("Party")?.Element("Contact")?.Element("Email")?.Value ?? "",
                        }
                    }
                },

                PaymentTerms = new List<PaymentTermsType>
                {
                    new PaymentTermsType
                    {
                        Note = new List<TextType>
                        {
                            new TextType
                            {
                                Value = xmlDoc.Root.Element("PaymentTerms")?.Value ?? "",
                            }
                        }
                    }
                },

                TaxTotal = new List<TaxTotalType> {
                    new TaxTotalType {
                        TaxAmount = new AmountType
                        {
                            currencyID = "TRY",
                            Value = decimal.Parse(xmlDoc.Root.Element("TaxTotal")?.Element("TaxAmount")?.Value ?? "0")
                        }
                    }
                },

                LegalMonetaryTotal = new MonetaryTotalType
                {
                    LineExtensionAmount = new AmountType
                    {
                        currencyID = "TRY",
                        Value = decimal.Parse(xmlDoc.Root.Element("LegalMonetaryTotal")?.Element("LineExtensionAmount")?.Value ?? "0"),
                    },
                    TaxExclusiveAmount = new AmountType
                    {
                        currencyID = "TRY",
                        Value = decimal.Parse(xmlDoc.Root.Element("LegalMonetaryTotal")?.Element("TaxExclusiveAmount")?.Value ?? "0"),
                    },
                    TaxInclusiveAmount = new AmountType
                    {
                        currencyID = "TRY",
                        Value = decimal.Parse(xmlDoc.Root.Element("LegalMonetaryTotal")?.Element("TaxInclusiveAmount")?.Value ?? "0"),
                    },
                    PayableAmount = new AmountType
                    {
                        currencyID = "TRY",
                        Value = decimal.Parse(xmlDoc.Root.Element("LegalMonetaryTotal")?.Element("PayableAmount")?.Value ?? "0"),
                    }
                },

                InvoiceLine = new List<InvoiceLineType>
                {
                    new InvoiceLineType
                    {
                        ID = xmlDoc.Root.Element("InvoiceLine")?.Element("ID")?.Value ?? "0",
                        InvoicedQuantity = new QuantityType
                        {
                            unitCode = "EA",
                            Value = Int32.Parse(xmlDoc.Root.Element("InvoiceLine")?.Element("InvoicedQuantity")?.Value ?? "0"),
                        },
                        LineExtensionAmount = new AmountType
                        {
                            currencyID = "TRY",
                            Value = decimal.Parse(xmlDoc.Root.Element("InvoiceLine")?.Element("LineExtensionAmount")?.Value ?? "0"),
                        },
                        Item = new ItemType
                        {
                            Description = new List<TextType>
                            {
                                new TextType
                                {
                                    Value = xmlDoc.Root.Element("InvoiceLine")?.Element("Item")?.Element("Description").Value,
                                }
                            }
                        },
                        Price = new PriceType
                        {
                            PriceAmount = new AmountType
                            {
                                currencyID = "TRY",
                                Value = decimal.Parse(xmlDoc.Root.Element("InvoiceLine")?.Element("Price")?.Element("PriceAmount")?.Value ?? "0"),
                            }
                        },
                        TaxTotal = new List<TaxTotalType>
                        {
                            new TaxTotalType
                            {
                                TaxAmount = new AmountType
                                {
                                    currencyID = "TRY",
                                    Value = decimal.Parse(xmlDoc.Root.Element("InvoiceLine")?.Element("TaxTotal")?.Element("TaxAmount")?.Value ?? "0"),
                                }
                            }
                        },
                    }
                }

            };



            // Step 4: Generate UBL XML
            var serializer = new XmlSerializer(typeof(InvoiceType));
            var ublXmlFile = "C:\\Users\\doguk\\OneDrive\\Desktop\\Jobs\\SoftNet\\XMLtoUBL\\XMLtoUBL\\output.ubl.xml";


            using (var fileStream = new FileStream(ublXmlFile, FileMode.Create))
            {
                serializer.Serialize(fileStream, invoice);
            }

            Console.WriteLine("UBL XML file generated successfully.");

        }
    }
}
