using Godot;
using LLama.Common;
using LLama;
using System;
using static System.Collections.Specialized.BitVector32;

[Tool]
public partial class ModelConfigInterface : Control
{
 

    // UI elements
    private Button selectChatPathButton, clearChatPathButton, selectEmbedderPathButton, clearEmbedderPathButton, selectClipPathButton, clearClipPathButton;
    private Label chatContextSizeLabel, chatModelGpuLayerCountLabel;
    private FileDialog selectChatModelFileDialog, selectClipModelFileDialog, selectEmbedderModelFileDialog;
    private HSlider chatContextSizeHSlider, chatModelGpuLayerCountHSlider;

    // Chat model params
    private int chatGpuLayerCount;
    private double chatContextSizeSliderValue;
    private uint chatContextSize;

    // Chat model vars
    private LLamaWeights chatWeights = null;
    private LLamaContext chatContext = null;
    private string chatModelPath = null;

    // Clip (LLaVa) model vars
    private LLavaWeights clipWeights = null;
    private string clipModelPath = null;

    
    private string embedderModelPath = null;

    // Executor
    private InteractiveExecutor executor = null;


    public override void _EnterTree()
    {
        
    }

    public override void _Ready()
    {
        // Chat model vars
        chatContextSizeHSlider = GetNode<HSlider>("%ChatContextSizeHSlider");
        chatContextSizeLabel = GetNode<Label>("%ChatContextSizeLabel");

        chatModelGpuLayerCountLabel = GetNode<Label>("%ChatModelGpuLayerCountLabel");
        chatModelGpuLayerCountHSlider = GetNode<HSlider>("%ChatModelGpuLayerCountHSlider");


        selectChatPathButton = GetNode<Button>("%SelectChatPathButton");
        clearChatPathButton = GetNode<Button>("%ClearChatPathButton");
        selectChatModelFileDialog = GetNode<FileDialog>("%SelectChatPathFileDialog");

        // Clip model vars
        selectClipPathButton = GetNode<Button>("%SelectClipPathButton");
        clearClipPathButton = GetNode<Button>("%ClearClipPathButton");
        selectClipModelFileDialog = GetNode<FileDialog>("%SelectClipPathFileDialog");


        // Embedder model vars
        selectEmbedderPathButton = GetNode<Button>("%SelectEmbedderPathButton");
        clearEmbedderPathButton = GetNode<Button>("%ClearEmbedderPathButton");
        selectEmbedderModelFileDialog = GetNode<FileDialog>("%SelectEmbedderPathFileDialog");

        InitializeParameters();
        SetupSignals();
        

    }

    private void InitializeParameters()
    {
        chatGpuLayerCount = (int)chatModelGpuLayerCountHSlider.Value;
        chatModelGpuLayerCountLabel.Text = chatGpuLayerCount.ToString();

        chatContextSizeSliderValue = chatContextSizeHSlider.Value;
        chatContextSize = getContextSize(chatContextSizeSliderValue);
        chatContextSizeLabel.Text = chatContextSize.ToString();
    }

    private void SetupSignals()
    {
        // Chat signals
        chatContextSizeHSlider.ValueChanged += OnChatContextSizeHSliderValueChanged;
        chatModelGpuLayerCountHSlider.ValueChanged += OnModelGpuLayerCountHSliderValueChanged;

        selectChatPathButton.Pressed += OnSelectChatModelButtonPressed;

        selectChatModelFileDialog.FileSelected += OnChatModelSelected;


        // Embedder signals
        selectEmbedderPathButton.Pressed += OnSelectEmbedderModelPressed;

        selectEmbedderModelFileDialog.FileSelected += OnEmbedderModelSelected;

        // Clip signals
        selectClipPathButton.Pressed += OnSelectClipModelButtonPressed;
        selectClipModelFileDialog.FileSelected += OnClipModelSelected;
    }

    private void OnClipModelSelected(string path)
    {
        throw new NotImplementedException();
    }

    private void OnEmbedderModelSelected(string path)
    {
        loadEmbedderModelButton.Disabled = false;
        chatModelPath = path;
    }


    private void OnSelectEmbedderModelPressed()
    {
        selectEmbedderModelFileDialog.PopupCentered();
    }






    private uint getContextSize(double value)
    {
        // This sets a minimum context size for the slider
        double min_exponent = 5;
        if (value == 0) return 0;
        else
        {
            return (uint)Math.Pow(2, value + min_exponent);
        }
    }

    private void OnChatContextSizeHSliderValueChanged(double value)
    {
        chatContextSizeSliderValue = chatContextSizeHSlider.Value;
        chatContextSize = getContextSize(chatContextSizeSliderValue);
        chatContextSizeLabel.Text = chatContextSize.ToString();
    }

    private void OnSelectClipModelButtonPressed()
    {
        selectClipModelFileDialog.PopupCentered();
    }

    private void OnModelGpuLayerCountHSliderValueChanged(double value)
    {
        chatGpuLayerCount = (int)chatModelGpuLayerCountHSlider.Value;
        chatModelGpuLayerCountLabel.Text = chatGpuLayerCount.ToString();
    }

    private void OnSelectChatModelButtonPressed()
    {
        selectChatModelFileDialog.PopupCentered();
    }

    private void OnChatModelSelected(string path)
    {
        chatModelPath = path;
    }

    public override void _ExitTree()
    {
        
    }
}