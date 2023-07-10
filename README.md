# ApiKey
Just a simple API key test that rotates the keys on an Azure Function using Github Actions.  I found the shell script at https://www.davidguida.net/azure-function-automatic-keys-renewal/.  The part I had to figure out was writing the Action and getting the user access to the API and keyvault.

I created the user with the Azure CLI.
az ad sp create-for-rbac --name "key-manager" --role contributor --scopes /subscriptions/xxxxxxxxx-xxxx-xxxx-xxxx-xxxxxxxxxxxxxx/resourceGroups/resourcegroup_name

This generated the ${{ secrets.AZURE_CREDENTIALS }} to use in the yaml file.  This user will then need a couple other rights to get this working.  Read Access on the AAD to look up it's access, Contributor on the Azure Function and Key Vault Secrets Officer on the KeyVault.  THat last one took a bit of research.
