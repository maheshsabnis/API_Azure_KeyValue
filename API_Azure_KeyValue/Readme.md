
# Command line publish

 az webapp up --resource-group msitresgp --sku F1 --name testmaheshwebapp009 --location westeus 

 az webapp up --resource-group msitresgp --sku F1 --name testmaheshwebapp009 --location westus


# Eanable swagger

az webapp config appsettings set --resource-group msitresgp --sku F1 --name testmaheshwebapp009 --location westus --settings ASPNETCORE_ENVIRONMENT="Development"