This is a plugin for the Godot game engine that allows the user to load and run a local Large Language Model (LLM) in-engine using the [LLamaSharp](https://github.com/SciSharp/LLamaSharp) (v0.11.1) C# library.

# Run Mind Game stand-alone

1) Install [CUDA Toolkit 12.x](https://developer.nvidia.com/cuda-12-1-0-download-archive) if you haven't already (CPU inference support coming soon)
2) Download the [latest Mind Game release](https://github.com/adammikulis/MindGame/releases) for your platform and run the executable
3) Download a .gguf model of the Llama, Phi, or Mistral families
4) Load your model and have fun!

Recommended model: [Llama3-8B-Instruct](https://huggingface.co/bartowski/Meta-Llama-3-8B-Instruct-GGUF/tree/main)

Smaller model for those with less VRAM: [Phi-3](https://huggingface.co/microsoft/Phi-3-mini-4k-instruct-gguf/tree/main)

Another 7B model: [Mistral-7B-Instruct-v0.2](https://huggingface.co/TheBloke/Mistral-7B-Instruct-v0.2-GGUF/tree/main)



# Run Mind Game as a Godot plug-in

1) Install [CUDA Toolkit 12.x](https://developer.nvidia.com/cuda-12-1-0-download-archive) if you haven't already (CPU inference support coming soon)
2) Download and extract [Godot 4.3 dev5 (.NET version)](https://godotengine.org/article/dev-snapshot-godot-4-3-dev-5/)
3) Download/install [.NET8](https://dotnet.microsoft.com/en-us/download)
4) Clone/download this repo (or the most recent dev branch to have the most current features), open it with Godot 4.3 .NET, click Project > Project Settings > Plugins > Enabled (Mind Game).
5) Currently you have to manually add the [LLamaSharp](https://www.nuget.org/packages/LLamaSharp) and [Cuda12 backend](https://www.nuget.org/packages/LLamaSharp.Backend.Cuda12) or [Cpu backend](https://www.nuget.org/packages/LLamaSharp.Backend.Cpu) Nuget packages to the project solution, use Visual Studio Community for this or a visual NuGet Manager extension for VS Code.
6) Load a .gguf file of the Llama, Mistral, Mixtral, or Phi families to get going!


The lower quantization (q), the smaller the model is to run but at the cost of accuracy. Llama-3-8B-Instruct.Q4_K_M is a great middle-ground for those with 8GB of VRAM. The absolute smallest model [Phi-3-mini-128k-instruct.IQ1_S.gguf](https://huggingface.co/PrunaAI/Phi-3-mini-128k-instruct-GGUF-Imatrix-smashed/blob/main/Phi-3-mini-128k-instruct.IQ1_S.gguf) can run on less than 1GB of VRAM.

# Future steps
- Implement LLaVa support (including viewport analysis)
- Automatically include and reference LLamaSharp nuget packages
- Make Download Manager functional
- ~~Make a singleton to be able to access currently loaded model in-game~~ Complete 0.2.0-dev
- Transition to BatchedExecutor and add conversation forking/rewinding
- Add network graph generation
- Add project script crawling
- Expose LLamaSharp methods like quantization
- Integrate Kernel Memory for document ingestion

# Version History

## 0.2.0: 
- MindManager is now an autoload
- Model configurations can be saved/loaded
- MindAgent nodes can be added in the inspector
  
## 0.1.3:
- First release, model loading and chat enabled in engine bottom bar
