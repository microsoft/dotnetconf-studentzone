## Install additional apt packages
sudo apt-get update \
    && sudo apt-get install -y dos2unix libsecret-1-0 xdg-utils \
    && sudo apt-get clean -y && sudo rm -rf /var/lib/apt/lists/*

## Configure git
git config --global pull.rebase false
git config --global core.autocrlf input

## Enable local HTTPS for .NET
dotnet dev-certs https --trust

## CaskaydiaCove Nerd Font
# Uncomment the below to install the CaskaydiaCove Nerd Font
# mkdir $HOME/.local
# mkdir $HOME/.local/share
# mkdir $HOME/.local/share/fonts
# wget https://github.com/ryanoasis/nerd-fonts/releases/latest/download/CascadiaCode.zip
# unzip CascadiaCode.zip -d $HOME/.local/share/fonts
# rm CascadiaCode.zip

## AZURE BICEP CLI ##
# Uncomment the below to install Azure Bicep CLI.
az bicep install

## AZURE FUNCTIONS CORE TOOLS ##
# Uncomment the below to install Azure Functions Core Tools. Make sure you have installed node.js
npm i -g azure-functions-core-tools@4 --unsafe-perm true

## AZURE STATIC WEB APPS CLI ##
# Uncomment the below to install Azure Static Web Apps CLI. Make sure you have installed node.js
npm install -g @azure/static-web-apps-cli

## AZURE DEV CLI ##
# Uncomment the below to install Azure Dev CLI. Make sure you have installed Azure CLI and GitHub CLI
curl -fsSL https://aka.ms/install-azd.sh | bash

## NSwag CLI ##
# Uncomment the below to install NSwag CLI. Make sure you have installed node.js
npm install nswag -g

## OH-MY-POSH ##
# Uncomment the below to install oh-my-posh
sudo wget https://github.com/JanDeDobbeleer/oh-my-posh/releases/latest/download/posh-linux-amd64 -O /usr/local/bin/oh-my-posh
sudo chmod +x /usr/local/bin/oh-my-posh
