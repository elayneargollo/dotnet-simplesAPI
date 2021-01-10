# Consumindo o WebService dos Correios (SOAP - WSDL)

WSDL é um a descrição em formato XML de um Web Service que utilizará SOAP / RPC como protocolo. É o acrônimo de Web Services Description Language (Linguagem de Descrição de Serviços Web).
Está API retorna o endereço a partir do CEP digitado.

# Como usar 

<ul>
  <li>Projeto está em localhost, portanto, realize o clone na sua máquina.</li>
  <li>É possível que haja alguns conflitos, no terminal, digite o seguinte comando: dotnet restore.</li>
  <li>Ainda no terminal, suba a API : dotnet run.</li>
  <li>No navegador digite a seguinte URL: https://localhost:5001/api/endereco/?CEP=seuCEP.</li>
</ul>

## Pendências

<ul>
  <li>Não há tratamento de erro.</li>
  <li>Arquitetura pode ser melhorada .</li>
</ul>

## Material de Apoio

##### URL : https://apps.correios.com.br/SigepMasterJPA/AtendeClienteService/AtendeCliente?wsdl
##### Software Suporte : SoapUI 5.6.0
##### Documentação Apoio : https://www.correios.com.br/enviar-e-receber/precisa-de-ajuda/manual_rastreamentoobjetosws.pdf

