# VoiceNotesMAUI


## Descripción
**VoiceNotesMAUI** es una aplicación de notas desarrollada en **.NET MAUI 2026** que permite a los usuarios crear notas de texto y escucharlas en voz alta mediante **Text-to-Speech**.  

La aplicación sigue el patrón **MVVM**, separando claramente **Modelo**, **Vista** y **ViewModel**, lo que hace que el código sea limpio, mantenible y escalable.  

La interfaz natural implementada es **voz mediante Text-to-Speech**, que permite reproducir las notas guardadas.

---

## Tecnologías usadas
- **.NET MAUI 2026**  
- **C#**  
- **XAML** para la interfaz de usuario  
- **ObservableCollection** para actualización automática de listas  
- **TextToSpeech** para reproducción de voz  
- **MVVM** para separación de responsabilidades

---

## Estilos aplicados
- **Paleta de colores global** definida en `App.xaml`:
  - Fondo general gris claro (`#E5E5E5`)  
  - Tarjetas blancas para notas (`#FFFFFF`)  
  - Texto gris oscuro (`#333333`)  
  - Botones con colores primario, éxito y voz para acciones destacadas  
- **Bordes redondeados** usando `Border` (ya que `Frame` está obsoleto en .NET 9)  
- **Separación entre notas** mediante `ItemSpacing` en `CollectionView`  
- **Diseño responsive** para Android y Windows  
- Interfaz clara y profesional, con emojis para mejor experiencia visual  

---

## Animaciones
- **Botones con efecto rebote** al pulsar (`ScaleTo`), aplicado en:
  - **Agregar Nota**  
  - **Guardar Nota**  
  - **Reproducir Nota**

---

## Funcionalidades
1. **Navegación básica** usando `NavigationPage`  
2. **MainPage**:  
   - Muestra la lista de notas guardadas (`CollectionView`)  
   - Botón para agregar nuevas notas  
3. **AddNotePage**:  
   - Entrada manual de nuevas notas  
   - Botón para guardar la nota y volver a la lista  
4. **NoteDetailPage**:  
   - Muestra la nota seleccionada  
   - Botón para reproducir la nota mediante **Text-to-Speech**  
5. **MVVM**:
   - `Models/Nota.cs` → Define los datos de cada nota  
   - `ViewModels/MainViewModel.cs` → Contiene la lista de notas y lógica de agregar  
   - `ViewModels/AddNoteViewModel.cs` → Controla la creación de nuevas notas  
   - `ViewModels/NoteDetailViewModel.cs` → Controla la reproducción de voz  

---

## Interfaz natural
La aplicación utiliza **Text-to-Speech** para permitir al usuario escuchar sus notas en voz alta.  

---

## Cómo probarlo

1. Abre la solución **VoiceNotesMAUI** en **Visual Studio 2026**  
2. Asegúrate de tener instalado el workload **.NET MAUI**  
3. Selecciona el target:
   - **Windows Machine** para probar en PC  
   - **Android Emulator** para probar en un dispositivo Android  
4. Haz **Build → Clean Solution → Build Solution** para asegurarte de que todo compila  
5. Presiona **F5** para ejecutar la aplicación  
6. Flujo de prueba:
   - En la página **"📝 Mis notas"**, pulsa **➕ Agregar nota**  
   - Escribe una nota en el **Entry** y pulsa **💾 Guardar nota**  
   - La nota aparecerá automáticamente en la lista  
   - Selecciona la nota para ir a **NoteDetailPage**  
   - Pulsa **🔊 Reproducir nota** para escucharla mediante Text-to-Speech  
   - Observa la **animación de rebote** en los botones

---

## Estructura del proyecto

```bash
VoiceNotesMAUI/
│
├─ MVVM/
│   ├─ Models/
│   │   └─ Nota.cs
│   │
│   ├─ Views/
│   │   ├─ MainPage.xaml
│   │   ├─ MainPage.xaml.cs
│   │   ├─ AddNotePage.xaml
│   │   ├─ AddNotePage.xaml.cs
│   │   ├─ NoteDetailPage.xaml
│   │   └─ NoteDetailPage.xaml.cs
│   │
│   └─ ViewModels/
│       ├─ MainViewModel.cs
│       ├─ AddNoteViewModel.cs
│       └─ NoteDetailViewModel.cs
│
├─ App.xaml
├─ App.xaml.cs
└─ README.md
```
