#/bin/bash

# script for rotating keys found at https://www.davidguida.net/azure-function-automatic-keys-renewal/

subscription=$1
resourceGroup=$2
appName=$3
vaultName=$4
secretName=$5

echo "generating new default key for $subscription \ $resourceGroup \ $appName ..."

newKey=$(az functionapp keys set --key-name 'default' \
        --key-type functionKeys \
        --name $appName \
        --resource-group $resourceGroup \
        --subscription '$subscription' | jq '.value' | tr -d \" )

echo "updating value for secret $subscription \ $vaultName \ $secretName ..."

newSecretId=$(az keyvault secret set --subscription '$subscription' \
        --vault-name $vaultName \
        --name $secretName \
        --value $newKey | jq '.id')

echo "new secret id: $newSecretId"
