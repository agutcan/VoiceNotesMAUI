# VoiceNotesMAUI


## Descripción
VoiceNotesMAUI es una aplicación de notas desarrollada en **.NET MAUI 2026** que permite a los usuarios:

- Crear notas de texto.
- Escucharlas en voz alta mediante **Text-to-Speech**.
- Buscar notas usando un **filtro**.
- Eliminar notas individualmente.
- Ver un **contador de caracteres** al escribir una nueva nota.

La aplicación incluye navegación entre páginas y un diseño simple, moderno e intuitivo con tarjetas, sombras y colores definidos globalmente.

La **interfaz natural** implementada es **voz mediante Text-to-Speech**, que permite reproducir las notas guardadas.

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

- **Paleta de colores global**:
  - Fondo general gris claro (`#E5E5E5`).
  - Tarjetas de notas en blanco puro (`#FFFFFF`).
  - Botones de acción con colores semánticos (Azul para acciones, Rojo para eliminar, Naranja para voz).
- **Diseño visual**:
  - **Bordes redondeados** y **sombras suaves** en tarjetas y botones para crear profundidad.
  - **Iconografía intuitiva**: Uso de emojis y simbolos para facilitar la navegación.
  - **Layout optimizado**: Distribución de elementos ajustada para Windows y Android, asegurando que los botones de acción estén siempre al alcance visual del usuario.
  - **Feedback táctil**: Animaciones de rebote (`ScaleToAsync`) al interactuar con los elementos.
    
---

## Funcionalidades
1. **Navegación básica** usando `NavigationPage`  
2. **MainPage**:
   - Muestra la colección de notas mediante un `CollectionView`.
   - **Buscador con Placeholder**: Barra de búsqueda con icono de lupa para filtrar contenido.
   - **Acción de borrado**: Botón "✕" integrado en cada tarjeta con aviso de confirmación.
3. **AddNotePage**:
   - Interfaz de entrada para nuevas notas con contador de caracteres.
   - Botón de guardado con retorno automático a la lista principal.
4. **NoteDetailPage**:
   - Visualización del texto completo y fecha de creación.
   - **Reproducción de voz**: Botón posicionado estratégicamente tras el texto para una lectura inmediata. 
5. **MVVM**:
   - `Models/Nota.cs` → Define los datos de cada nota  
   - `ViewModels/MainViewModel.cs` → Contiene la lista de notas y lógica de agregar/eliminar
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
   - Puedes eliminar la nota pulsando en **X** 
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
