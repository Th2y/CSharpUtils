# 🧰 Unity-Core — Utilitários em C# para Unity

Biblioteca de **scripts utilitários reutilizáveis** em **C#**, desenvolvidos para uso em diferentes projetos **Unity**, com foco em organização, reaproveitamento de código e solução de problemas recorrentes do dia a dia no desenvolvimento de jogos.

---

## 📌 Visão Geral
Este repositório centraliza **scripts genéricos e independentes**, utilizados em projetos reais em Unity, evitando retrabalho e facilitando a manutenção e padronização entre projetos.

Os scripts podem ser utilizados tanto em:
- Prototipação rápida
- Projetos comerciais
- Ferramentas internas
- Jogos mobile, PC ou console

---

## 🎮 Organização do Repositório

### 📁 Scripts Gerais

- **ColorHelper.cs**  
  Funções auxiliares para manipulação e conversão de cores, facilitando ajustes visuais e reutilização de lógica relacionada a cores.

- **CompareStrings.cs**  
  Utilitário para comparação de strings, incluindo tratamentos para diferenças de capitalização, espaços ou formatos, evitando erros comuns em validações.

- **FlashColor.cs**  
  Script para efeitos visuais simples de “piscar” ou transição temporária de cores, muito utilizado em feedbacks visuais de UI ou gameplay.

- **MicrophonePermission.cs**  
  Gerencia permissões de microfone, especialmente útil para projetos mobile que utilizam entrada de áudio.

- **PauseGame.cs**  
  Controla o estado de pausa do jogo, incluindo gerenciamento de `Time.timeScale` e eventos relacionados.

- **RotateCanvasToCamera.cs**  
  Mantém um Canvas sempre orientado para a câmera, comum em interfaces em mundo 3D (World Space UI).

- **SafeAreaHandler.cs**  
  Ajusta automaticamente elementos de UI respeitando a **Safe Area** de dispositivos mobile (notch, barras do sistema, etc).

- **SessionController.cs**  
  Gerencia dados e estados de sessão do jogo, facilitando controle de fluxo entre cenas ou estados globais.

- **SliderTextUpdater.cs**  
  Atualiza textos dinamicamente a partir do valor de um `Slider`, muito utilizado em configurações de áudio, sensibilidade ou opções gráficas.

- **TextContainerFitter.cs**  
  Ajusta dinamicamente o tamanho de containers de UI com base no conteúdo de texto.

- **URLOpener.cs**  
  Utilitário simples para abertura de URLs externas a partir do jogo (ex: links, termos de uso, redes sociais).

- **VersionController.cs**  
  Controla e exibe informações de versão do projeto, auxiliando em builds, testes e validação de releases.

- **VersionSettings.cs**  
  Classe de configuração relacionada à versão do projeto, permitindo centralizar e reutilizar dados de versionamento.

- **VolumeControl.cs**  
  Gerencia controle de volume de áudio, integrando UI e sistema de áudio do Unity.

---

### 📁 newInputSystem
Scripts voltados ao **Unity Input System**, com foco em rebind dinâmico de controles.

- **RebindActionUI.cs**  
  Gerencia a interface de usuário para remapeamento de ações.

- **RebindActionUIEditor.cs**  
  Extensões e ajustes para visualização e configuração no Editor.

- **RebindSaveLoad.cs**  
  Responsável por salvar e carregar bindings personalizados definidos pelo jogador.

---

### 📁 scene
Scripts relacionados a gerenciamento e transição de cenas.

- **ChangeScene.cs**  
  Controla troca de cenas de forma centralizada.

- **SceneLoading.cs**  
  Gerencia carregamento de cenas, podendo ser estendido para loading assíncrono e telas de carregamento.

---

### 📁 editor
Scripts exclusivos para uso no **Editor da Unity**, auxiliando o fluxo de desenvolvimento.

- **DimensionChecker.cs**  
  Verifica dimensões e proporções de elementos, ajudando a manter padrões visuais.

- **StartFromScene.cs**  
  Versão específica para Editor, facilitando testes iniciando por cenas determinadas.

---

### 📄 Singleton.cs
Implementação genérica do padrão **Singleton**, utilizada para gerenciamento de instâncias únicas de forma segura e reutilizável.

---

## 📐 Princípios Adotados
- Código limpo e legível
- Scripts independentes e reutilizáveis
- Separação de responsabilidades
- Foco em produtividade e manutenção
- Soluções práticas aplicadas em projetos reais

---

## 🚀 Como Utilizar
1. Clone ou baixe o repositório
2. Copie os scripts desejados para seu projeto Unity
3. Utilize de forma independente ou adapte conforme a necessidade

```bash
git clone https://github.com/Th2y/CSharpUtils.git
