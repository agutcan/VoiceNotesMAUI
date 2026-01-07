# VoiceNotesMAUI

## Descripción
VoiceNotesMAUI es una aplicación de notas desarrollada en **.NET MAUI 2026** que permite a los usuarios crear notas de texto y escucharlas en voz alta mediante **Text-to-Speech**. La aplicación incluye navegación entre páginas y un diseño simple e intuitivo.

La interfaz natural implementada es **voz mediante Text-to-Speech**, lo que permite reproducir las notas que se han guardado.

---

## Tecnologías usadas
- **.NET MAUI 2026**  
- **C#**  
- **XAML** para el diseño de la interfaz  
- **ObservableCollection** para la actualización automática de listas  
- **TextToSpeech** para la reproducción de voz

---

## Estilos aplicados
- **Paleta de colores global** definida en `App.xaml`:
  - Fondo general gris claro (`#E5E5E5`)  
  - Tarjetas blancas para notas (`#FFFFFF`)  
  - Texto gris oscuro (`#333333`)  
  - Botones con colores primario/éxito/voz para destacar acciones  
- **Bordes redondeados** y `Border` para las tarjetas de notas, reemplazando `Frame` (obsoleto en .NET 9)  
- **Separación real entre notas** usando `ItemSpacing` en `CollectionView`  
- Interfaz coherente y profesional, adaptada a móvil y Windows

---

## Animaciones
- **Botones con efecto rebote** al pulsar (`ScaleTo`), aplicado en:
  - **Agregar Nota**  
  - **Guardar Nota**  
  - **Reproducir Nota**

---

## Funcionalidades
1. **Navegación básica** usando `NavigationPage`.  
2. **MainPage**:  
   - Muestra la lista de notas guardadas (`CollectionView`).  
   - Botón para agregar nuevas notas.  
3. **AddNotePage**:  
   - Entrada manual de nuevas notas.  
   - Botón para guardar la nota y volver a la lista.  
4. **NoteDetailPage**:  
   - Muestra la nota seleccionada.  
   - Botón para reproducir la nota mediante **Text-to-Speech**.  
5. La lista se actualiza automáticamente gracias a **ObservableCollection**.

---

## Interfaz natural
La aplicación utiliza **Text-to-Speech** para permitir al usuario escuchar sus notas en voz alta.  

---

## Cómo probarlo

1. Abre la solución **VoiceNotesMAUI** en **Visual Studio 2026**.  
2. Asegúrate de tener instalado el workload **.NET MAUI**.  
3. Selecciona el target:
   - **Windows Machine** para probar en PC.  
   - **Android Emulator** para probar en un dispositivo Android.  
4. Haz **Build → Clean Solution → Build Solution** para asegurarte de que todo compila.  
5. Presiona **F5** para ejecutar la aplicación.  
6. Flujo de prueba:
   - En la página **"Mis Notas"**, pulsa el botón **"Agregar Nota"**.  
   - Escribe una nota en el **Entry** y pulsa **"Guardar Nota"**.  
   - La nota aparecerá automáticamente en la lista.  
   - Selecciona la nota para ir a **NoteDetailPage**.  
   - Pulsa **"Reproducir Nota"** para escucharla mediante Text-to-Speech.

---

## Estructura del proyecto

```bash
VoiceNotesMAUI/
│
├─ App.xaml.cs
├─ MainPage.xaml
├─ MainPage.xaml.cs
├─ AddNotePage.xaml
├─ AddNotePage.xaml.cs
├─ NoteDetailPage.xaml
├─ NoteDetailPage.xaml.cs
└─ README.md
```
