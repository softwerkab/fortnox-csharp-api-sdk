# csharp-api-sdk
C# SDK for developing integrations towards the Fortnox API.

This is a guide to help developers to get started with the .NET SDK by developing a simple console application which creates, retrives, deletes and search for a customer.

For a full API reference please visit [developer.fortnox.se/documentation/](http://developer.fortnox.se/documentation/)


## Getting started

### Create a console application project in Visual Studio 2010
1.  Start Visual Studio and select the option to create a new project.
2.  Select Console Application.
3.  Name the project FortnoxAPILibraryDemo
4.  Click OK to create the Project

![](http://developer.fortnox.se/wp-content/uploads/2014/04/sdk.png)

### Adding a reference to the Fortnox API
1.  In the Solution Explorer right-click References and select Add Reference…
2.  Locate the file FortnoxAPILibrary.dll file on your computer and add the reference

![](http://developer.fortnox.se/wp-content/uploads/2014/04/sdk2.png)

![](http://developer.fortnox.se/wp-content/uploads/2014/04/sdk11.png)

### Adding namespaces 
To be able to use Fortnox API you need to add the two namespaces `FortnoxAPILibrary` and
`FortnoxAPILibrary.Connectors`

![](http://developer.fortnox.se/wp-content/uploads/2014/04/sdk4.png)

## Connect to Fortnox API
Before we can send and receive any data to/from Fortnox we need to provide an `access-token` and a
`client-secret`. This is done by using the static class `ConnectionCredentials` and the properties
`AccessToken` and `ClientSecret`.

```C#
static void Main(string[] args)
{ 
   ConnectionCredentials.AccessToken = "{Generated GUID}"; 
   ConnectionCredentials.ClientSecret = "{Generated alphanumeric string}"; 
}
```

## Error handling
To capture all error messages it is recommended to always use try - catch statements.

```C#
static void Main(string[] args) 
{ 
   ConnectionCredentials.AccessToken = "{Generated GUID}"; 
   ConnectionCredentials.ClientSecret = "{Generated alphanumeric string}"; 

   try 
   {

   } 
   catch (Exception ex) 
   { 
      Console.WriteLine(ex.Message); 
   } 
}
```

## Create a customer
To create a customer we start by creating an instance of the Customer object. With an instance in place we populate it with data.

> NOTE! All fields in the SDK are of type string.

```C#
static void Main(string[] args) 
{ 
   ConnectionCredentials.AccessToken = "{Generated GUID}"; 
   ConnectionCredentials.ClientSecret = "{Generated alphanumeric string}"; 

   try 
   {
      Customer customer = new Customer();
      customer.CustomerNumber = "1";
      customer.Name = "Stefan Andersson";
   } 
   catch (Exception ex) 
   { 
      Console.WriteLine(ex.Message); 
   } 
}
```

To be able to create, update, delete a customer in Fortnox we have to create an instance of
`CustomerConnector` which is the class that handles the communication with Fortnox.


```C#
static void Main(string[] args) 
{ 
   ConnectionCredentials.AccessToken = "{Generated GUID}"; 
   ConnectionCredentials.ClientSecret = "{Generated alphanumeric string}"; 

   try 
   {
      Customer customer = new Customer();
      customer.CustomerNumber = "1";
      customer.Name = "Stefan Andersson";

      CustomerConnector customerConnector = new CustomerConnector();
      customerConnector.Create(customer);
   } 
   catch (Exception ex) 
   { 
      Console.WriteLine(ex.Message); 
   } 
}
```

### Error handling
To check if there was a problem when creating the customer we check if the property `HasError` on the
`CustomerConnector` object is true.

```C#
if (customerConnector.HasError) 
{ 
   Console.WriteLine(customerConnector.Error.Message); 
}
```

### Creating a customer - complete example

```C#
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using FortnoxAPILibrary; 
using FortnoxAPILibrary.Connectors; 

namespace FortnoxAPILibraryDemo 
{ 
   class Program 
   { 
      static void Main(string[] args) 
      { 
         ConnectionCredentials.AccessToken = "{Generated GUID}"; 
         ConnectionCredentials.ClientSecret = "{Generated alphanumeric string}"; 

         try 
         { 
            Customer customer = new Customer(); 
            customer.CustomerNumber = "123";  customer.Name = "Customer 123";

            CustomerConnector customerConnector = new CustomerConnector(); 

            Customer createdCustomer = customerConnector.Create(customer); 

            if (customerConnector.HasError) 
            { 
               Console.WriteLine(customerConnector.Error.Message); 
            } 
         } 
         catch (Exception ex) 
         { 
            Console.WriteLine(ex.Message); 
         } 
      } 
   } 
}
```

## Get a specific customer
To get a specific customer from Fortnox we use the method `Get` on the `CustomerConnector` object.
The `Get` method takes a customer number as parameter and returns the customer that was found. If
no customer is found we get an error message in the property `CustomerConnector.Error.Message`.

### Getting a customer with CustomerNumber 123 - complete example

```C#
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using FortnoxAPILibrary; 
using FortnoxAPILibrary.Connectors; 

namespace FortnoxAPILibraryDemo 
{ 
   class Program 
   { 
      static void Main(string[] args) 
   { 
      ConnectionCredentials.AccessToken = "{Generated GUID}"; 
      ConnectionCredentials.ClientSecret = "{Generated alphanumeric string}"; 

      try 
      { 
         CustomerConnector customerConnector = new CustomerConnector(); 
         Customer customer = customerConnector.Get("123"); 

         if (customerConnector.HasError) 
         { 
            Console.WriteLine(customerConnector.Error.Message);  }
         }
         catch (Exception ex) 
         { 
            Console.WriteLine(ex.Message); 
         } 
      } 
   } 
}
```

## Searching for customers
If you want to search for customers you use the method `Find` on the `CustomerConnector` object. The
method `Find` takes no parameters and returns a list of customers.

To be able to limit the search results you use the properties of the `CustomerConnector` object. See
the code example below where the customer name is the parameter to search for. It is possible to
combine as many search parameters as you want.

Please refer to the [API documentation](http://developer.fortnox.se/documentation/resources/customers/) for more information on which fields that are searchable.

### Search for a customer named Stefan - Complete example

```C#
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using FortnoxAPILibrary; 
using FortnoxAPILibrary.Connectors; 

namespace FortnoxAPILibraryDemo 
{ 
   class Program 
   { 
      static void Main(string[] args) 
      { 
         ConnectionCredentials.AccessToken = "{Generated GUID}"; 
         ConnectionCredentials.ClientSecret = "{Generated alphanumeric string}"; 

         try 
         { 
            CustomerConnector customerConnector = new CustomerConnector(); 
            customerConnector.Name = "Stefan"; 
            Customers customers = customerConnector.Find();

            if (customerConnector.HasError) 
            { 
               Console.WriteLine(customerConnector.Error.Message); 
            } 
         } 
         catch (Exception ex) 
         { 
            Console.WriteLine(ex.Message); 
         } 
      } 
   } 
}
```

> NOTE! There is a difference between the objects `Customer` and `Customers`. `Customer` is used when a single customer is returned and `Customers` is returned when a list of customers is returned.

## Deleting a customer
To delete a customer the method `Delete` on the `CustomerConnector` object is used. The method takes
a customer number as parameter and returns nothing.

### Deleting a customer - complete example
```C#
using System; 
using System.Collections.Generic; 
using System.Linq; 
using System.Text; 
using FortnoxAPILibrary; 
using FortnoxAPILibrary.Connectors; 

namespace FortnoxAPILibraryDemo 
{ 
   class Program 
   { 
      static void Main(string[] args) 
      { 
         ConnectionCredentials.AccessToken = "{Generated GUID}"; 
         ConnectionCredentials.ClientSecret = "{Generated alphanumeric string}"; 

         try 
         {  
            CustomerConnector customerConnector = new CustomerConnector(); 
            customerConnector.Delete("123"); 

            if (customerConnector.HasError) 
            {  
               Console.WriteLine(customerConnector.Error.Message); 
            } 
         } 
         catch (Exception ex) 
         {
            Console.WriteLine(ex.Message);
         } 
      } 
   } 
}
```