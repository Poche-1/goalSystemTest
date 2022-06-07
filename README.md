## Código fuente test CRUD (GoalSystems)

To execute this solution, the following steps must be carried out

1. Clone the repository

2. Located in the root folder execute the following command

```bash
$ docker-compose up
```
3. To enter the container Mariadb enter the following command

```bash
$ mysql -h 172.16.238.11-P 3306 --protocol=TCP -u root -p
```
4. Use the password that is described in the docker-compose.yml file
5. In the "script_Sql" folder run the database scripts to create the tables that we will use for these tests
6. Consult documentation Swagger /swagger/index.html "Dev envioremnt"


###### Structure 

1.  DB:
        Supplier >
            Product
        
        Categorie >>
            Product >>
                Inventory >
                        Inputs
                        Outputs
                
2. Functional Logic:

    Supplier>>
        GetSupplier >>
            - GetProduct
            - UpdateProduct
            - IncludeProduct
        AddSupplier
        UpdateSupplier

    Categorie>>
        GetCategorie
        AddCategorie
        UpdateCategorie

    CreateInventory>>
        AddInput
        AddOutput
        UpdateCost
        UpdateState

3. Security>>
    - Autentication (JWT)>>
        -Authorization (ROLES)>>
            - Filter Supplier
            - Filter Product

###### Assumptions

1. The entry of a new product must always have a related supplier
2. Removing the item from a product must be done by an exit command
3. The inventory will be updated automatically with each new entry or exit order
4. The expiration time depends on the entry of the product, not all products have the same date although they do have the same characteristics (To be implemented)

###### Document the reasons why you use a third-party nuget package.
For optimization, security and flexibility when carrying out developments

        
