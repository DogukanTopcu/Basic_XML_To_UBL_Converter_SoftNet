# XML to UBL Formatter:

## Input (data.xml)
```xml
<?xml version="1.0" encoding="utf-8" ?>
<Invoice>
    <ID>INV-2023-001</ID>
	
    <IssueDate>2023-07-06</IssueDate>
	
    <DueDate>2023-07-20</DueDate>
	
    <AccountingSupplyParty>
    	<Party>
    	    <PartyName>
    	    	<Name>Supplier Company 1</Name>
    	    </PartyName>
    	    <PostalAddress>
    	    	<StreetName>Main Street</StreetName>
    	    	<City>Cityville</City>
    	    	<PostalZone>35535</PostalZone>
    	    	<Country>
    	    		<Name>Country</Name>
    	    	</Country>
    	    </PostalAddress>
    	    <Contact>
    	    	<Telephone>+1234567890</Telephone>
    	    	<Email>dogukantopcu35@gmail.com</Email>
    	    </Contact>
    	</Party>
    </AccountingSupplyParty>
    
    <AccountingCustomerParty>
    	<Party>
    	    <PartyName>
    	    	<Name>Customer Company</Name>
    	    </PartyName>
    	    <PostalAddress>
    	    	<StreetName>First Avenue</StreetName>
    	    	<City>Townville</City>
    	    	<PostalZone>35535</PostalZone>
    	    	<Country>
    	    		<Name>Country</Name>
    	    	</Country>
    	    </PostalAddress>
    	    <Contact>
    	    	<Telephone>+9876543210</Telephone>
    	    	<Email>customer@example.com</Email>
    	    </Contact>
    	</Party>
    </AccountingCustomerParty>
    
    <PaymentTerms>Net 30 Days</PaymentTerms>
    
    <TaxTotal>
    	<TaxAmount>500.00</TaxAmount>
    </TaxTotal>
    
    <LegalMonetaryTotal>
    	<LineExtensionAmount>2500.00</LineExtensionAmount>
    	<TaxExclusiveAmount>2000.00</TaxExclusiveAmount>
    	<TaxInclusiveAmount>2500.00</TaxInclusiveAmount>
    	<PayableAmount>3000.00</PayableAmount>
    </LegalMonetaryTotal>
    
    <InvoiceLine>
    	<ID>1</ID>
    	<InvoicedQuantity>5</InvoicedQuantity>
    	<LineExtensionAmount>1000.00</LineExtensionAmount>
    	<Item>
    		<Description>Product A</Description>
    	</Item>
    	<Price>
    		<PriceAmount>200.00</PriceAmount>
    	</Price>
    	<TaxTotal>
    		<TaxAmount>200.00</TaxAmount>
    	</TaxTotal>
    </InvoiceLine>
	
</Invoice>

```


## Output (output.ubl.xml)
```xml
<?xml version="1.0"?>
<Invoice xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xmlns:xsd="http://www.w3.org/2001/XMLSchema" xmlns:cac="urn:oasis:names:specification:ubl:schema:xsd:CommonAggregateComponents-2" xmlns:cbc="urn:oasis:names:specification:ubl:schema:xsd:CommonBasicComponents-2" xmlns="urn:oasis:names:specification:ubl:schema:xsd:Invoice-2">
  <cbc:ID>INV-2023-001</cbc:ID>
  <cbc:IssueDate>2023-07-06</cbc:IssueDate>
  <cbc:DueDate>2023-07-20</cbc:DueDate>
  <cac:AccountingSupplierParty>
    <cac:Party>
      <cac:PartyName>
        <cbc:Name>Supplier Company 1</cbc:Name>
      </cac:PartyName>
      <cac:PostalAddress>
        <cbc:StreetName>Main Street</cbc:StreetName>
        <cbc:CityName>Cityville</cbc:CityName>
        <cbc:PostalZone>35535</cbc:PostalZone>
        <cac:Country>
          <cbc:Name>Country</cbc:Name>
        </cac:Country>
      </cac:PostalAddress>
      <cac:Contact>
        <cbc:Telephone>+1234567890</cbc:Telephone>
        <cbc:ElectronicMail>dogukantopcu35@gmail.com</cbc:ElectronicMail>
      </cac:Contact>
    </cac:Party>
  </cac:AccountingSupplierParty>
  <cac:AccountingCustomerParty>
    <cac:Party>
      <cac:PartyName>
        <cbc:Name>Customer Company</cbc:Name>
      </cac:PartyName>
      <cac:PostalAddress>
        <cbc:StreetName>First Avenue</cbc:StreetName>
        <cbc:CityName>Townville</cbc:CityName>
        <cbc:PostalZone>35535</cbc:PostalZone>
        <cac:Country>
          <cbc:Name>Country</cbc:Name>
        </cac:Country>
      </cac:PostalAddress>
      <cac:Contact>
        <cbc:Telephone>+9876543210</cbc:Telephone>
        <cbc:ElectronicMail>customer@example.com</cbc:ElectronicMail>
      </cac:Contact>
    </cac:Party>
  </cac:AccountingCustomerParty>
  <cac:PaymentTerms>
    <cbc:Note>Net 30 Days</cbc:Note>
  </cac:PaymentTerms>
  <cac:TaxTotal>
    <cbc:TaxAmount currencyID="TRY">500.00</cbc:TaxAmount>
  </cac:TaxTotal>
  <cac:LegalMonetaryTotal>
    <cbc:LineExtensionAmount currencyID="TRY">2500.00</cbc:LineExtensionAmount>
    <cbc:TaxExclusiveAmount currencyID="TRY">2000.00</cbc:TaxExclusiveAmount>
    <cbc:TaxInclusiveAmount currencyID="TRY">2500.00</cbc:TaxInclusiveAmount>
    <cbc:PayableAmount currencyID="TRY">3000.00</cbc:PayableAmount>
  </cac:LegalMonetaryTotal>
  <cac:InvoiceLine>
    <cbc:ID>1</cbc:ID>
    <cbc:InvoicedQuantity unitCode="EA">5</cbc:InvoicedQuantity>
    <cbc:LineExtensionAmount currencyID="TRY">1000.00</cbc:LineExtensionAmount>
    <cac:TaxTotal>
      <cbc:TaxAmount currencyID="TRY">200.00</cbc:TaxAmount>
    </cac:TaxTotal>
    <cac:Item>
      <cbc:Description>Product A</cbc:Description>
    </cac:Item>
    <cac:Price>
      <cbc:PriceAmount currencyID="TRY">200.00</cbc:PriceAmount>
    </cac:Price>
  </cac:InvoiceLine>
</Invoice>
```