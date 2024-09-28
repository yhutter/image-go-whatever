using Raylib_CSharp.Colors;
using Raylib_CSharp.Rendering;
using Raylib_CSharp.Windowing;

Window.Init(1280, 720, "Image Go Whatever");

while (!Window.ShouldClose()) {
    Graphics.BeginDrawing();
    Graphics.ClearBackground(Color.SkyBlue);

    Graphics.DrawText("Basic Window!", 10, 10, 20, Color.White);

    Graphics.EndDrawing();
}
Window.Close();