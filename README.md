# Jokepon

![Pedra, Papel e Tesoura](https://github.com/Ngofilho/Jokepon/blob/assets/jokepon.jpg?raw=true)

## Como utilizar
Navegar até pasta contendo o executável `Jokepon.exe` e executar.
Selecionar entre as opções *1 - Pedra*, *2 - Papel* ou *3 - Tesoura* ou *4 - Sair*.
O computador irá selecionar aleatoriamente entre valores 1 a 3.

## Regra de negócio
O código abaixo, embora não atenda o clean code com relação a quantidade de linhas dentro de um método, ele mantém simples a implementação para validar o valor escolhido pelo jogador e comparar com o valor gerado aleatoriamente pela máquina.
Foi feito dessa forma para manter o KISS.
Poderia ser feito uma implementação utilizando o `Command` e/ou também `Strategy`. Seria necessário gerar mais classes.

```csharp
switch (opcao)
{
    case 1:
        EscreveTextoNaJanela("", 2, 9);
        if (valorMaquina == 2)
            DesenhaResultado(valorMaquina, "Perdeu");
        else if (valorMaquina == 1)
            DesenhaResultado(valorMaquina, "Empate");
        else
            DesenhaResultado(valorMaquina, "Ganhou");
        break;

    case 2:
        EscreveTextoNaJanela("", 2, 9);
        if (valorMaquina == 3)
            DesenhaResultado(valorMaquina, "Perdeu");
        else if (valorMaquina == 2)
            DesenhaResultado(valorMaquina, "Empate");
        else
            DesenhaResultado(valorMaquina, "Ganhou");
        break;

    case 3:
        EscreveTextoNaJanela("", 2, 9);
        if (valorMaquina == 1)
            DesenhaResultado(valorMaquina, "Perdeu");
        else if (valorMaquina == 3)
            DesenhaResultado(valorMaquina, "Empate");
        else
            DesenhaResultado(valorMaquina, "Ganhou");
        break;
    case 4:
        Console.Clear();
        Environment.Exit(0);
        break;
    default:
        break;
}

```

###### Requisitos
.Net 8.0 (Testado somente no Windows).
