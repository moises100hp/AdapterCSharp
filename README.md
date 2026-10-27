# Padrão Adapter

Este projeto de estudo demonstra o padrão de projeto **Adapter** em uma aplicação de console C#. O objetivo é permitir que o código cliente use uma interface comum para reproduzir formatos de mídia cujas classes têm formas diferentes de executar a reprodução.

## O problema ilustrado

O cliente precisa tocar arquivos de mídia, mas as implementações disponíveis não compartilham a mesma API:

- `Mp3Player` oferece o método de instância `Play`.
- `Mp4Player` oferece o método estático `Executar`.

Sem uma adaptação, o cliente precisaria conhecer e tratar cada uma dessas diferenças diretamente. O padrão Adapter envolve cada implementação com uma classe que apresenta uma interface uniforme.

## Estrutura do exemplo

| Papel no padrão | Arquivo | Responsabilidade |
| --- | --- | --- |
| Interface-alvo (*Target*) | [`IPlayer`](Adapter/Adapters/IPlayer.cs) | Define a operação que o cliente espera: `Play(string file)`. |
| Adaptador concreto (*Adapter*) | [`Mp3PlayerAdapter`](Adapter/Adapters/Mp3PlayerAdapter.cs) | Implementa `IPlayer` e encaminha a reprodução para `Mp3Player`. |
| Adaptador concreto (*Adapter*) | [`Mp4PlayerAdapter`](Adapter/Adapters/Mp4PlayerAdapter.cs) | Implementa `IPlayer` e converte a chamada para `Mp4Player.Executar`. |
| Serviço adaptado (*Adaptee*) | [`Mp3Player`](Adapter/Libs/Mp3Player.cs) | Implementa a reprodução de MP3 com sua própria API. |
| Serviço adaptado (*Adaptee*) | [`Mp4Player`](Adapter/Libs/Mp4Player.cs) | Implementa a reprodução de MP4 com sua própria API. |
| Cliente (*Client*) | [`Program.cs`](Adapter/Program.cs) | Lê o nome do arquivo, escolhe um adaptador e chama `Play` pela interface comum. |

## Como o fluxo funciona

1. O programa solicita o nome do arquivo, por exemplo, `musica.mp3`.
2. Identifica a extensão e seleciona o adaptador correspondente.
3. O cliente chama `Play` por meio de `IPlayer`.
4. O adaptador traduz essa chamada para a API específica do serviço adaptado.

Assim, o cliente não precisa chamar `Mp3Player.Play` ou `Mp4Player.Executar` diretamente: ambos são acessados pela abstração `IPlayer`.

## Executar

É necessário ter o SDK do **.NET 10** instalado. Na raiz do repositório, execute:

```bash
dotnet run --project Adapter/Adapter.csproj
```

Quando solicitado, informe um arquivo com extensão `.mp3` ou `.mp4`. O programa exibirá uma mensagem indicando a reprodução simulada. Para outra extensão, exibirá uma mensagem de incompatibilidade.

## Observação sobre a demonstração

Este é um exemplo didático: não há decodificação ou reprodução real de áudio e vídeo. A seleção da extensão é sensível a maiúsculas e minúsculas e pressupõe que o nome informado contenha um ponto seguido da extensão.
