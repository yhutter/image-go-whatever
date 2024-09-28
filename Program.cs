using System.Numerics;
using image_go_whatever;
using Raylib_CSharp.Colors;
using Raylib_CSharp.Fonts;
using Raylib_CSharp.Interact;
using Raylib_CSharp.IO;
using Raylib_CSharp.Rendering;
using Raylib_CSharp.Textures;
using Raylib_CSharp.Windowing;


const int windowWidth = 1280;
const int windowHeight = 720;
const int maxFontSize = 128; 

Window.Init(windowWidth, windowHeight, "Image Go Whatever");
ColorScheme.SetTheme(ColorScheme.Theme.Light);

Font font = Font.LoadEx("Ressources/Inter.ttf", maxFontSize, null);

Texture2D? imageTexture = null;

while (!Window.ShouldClose()) {
    if (Input.IsKeyPressed(KeyboardKey.T))
    {
        ColorScheme.ToggleTheme();
    }
    Graphics.BeginDrawing();
    Graphics.ClearBackground(ColorScheme.GetColor(ColorScheme.ColorFor.Background));

    int fontSize = 32;
    string text = "Drag and Drop Image here";
    var fontMeasurement = TextManager.MeasureTextEx(font, text, fontSize,1.0f);
    

    Vector2 fontPosition = Vector2.Zero;
    fontPosition.X = (float)(windowWidth / 2 - 0.5 * fontMeasurement.X);
    fontPosition.Y = (float)(windowHeight/ 2 - 0.5 * fontMeasurement.Y);
    
    Graphics.DrawTextEx(font, text, fontPosition, fontSize,1.0f, ColorScheme.GetColor(ColorScheme.ColorFor.Text));
    

    if (FileManager.IsFileDropped())
    {
        FilePathList droppedFiles = FileManager.LoadDroppedFiles();
        // TODO: Handle multiple files
        var imagePath = droppedFiles.Paths[0];
        imageTexture = Texture2D.Load(imagePath);
        // TODO: Currently only png images are supported by Raylib
        
        FileManager.UnloadDroppedFiles(droppedFiles);
    }

    if (imageTexture.HasValue)
    {
        Graphics.DrawTexture(imageTexture.Value, 0, 0, Color.White);
    }
    Graphics.EndDrawing();
}


Window.Close();