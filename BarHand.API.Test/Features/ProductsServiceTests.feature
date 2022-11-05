Feature: ProductsServiceTests
	Ass a Developer
	I Want to add new Product through API
	In order to make it available for application

Background: 
	Given the EndPoint https://localhost:7070/api/v1/products is available
	
	@product-adding
	Scenario: Add Product with unique Title
		When a Post Request is sent
		| Name   | Description      | NumberOfSales | Available | SupplierId |
		| Sample | A Sample Product | 1             | true      | 1          |
	Then A Response is received with Status 200
	And a Product Resource is included in Response Body
	| Id | Name   | Description      | NumberOfSales | Available | SupplierId |
	| 1  | Sample | A Sample Product | 1             | true      | 1          |
 
@product-adding
Scenario: Add Product with existing Title
	Given A Product is already stored
	  | Id | Name      | Description         | NumberOfSales | Available | SupplierId |
	  | 1  | Coca Cola | Product description | 17            | true      | 1          |
    When a Post Request is sent
   	| Name      | Description         | NumberOfSales | Available | SupplierId |
    | Coca Cola | Product description | 17            | true      | 1          |
   Then A Response is received with Status 400
   And Error Message is returned with value "Products name already existist."