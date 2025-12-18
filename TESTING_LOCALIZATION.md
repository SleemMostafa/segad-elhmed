# Testing Localization

## Application is Running!

Your application is now running at: **http://localhost:5271**

## How to Test Language Switching

1. **Open your browser** and navigate to http://localhost:5271

2. **Check the language switcher** button in the navigation bar (top-right area)
   - If current language is English, you should see: **العربية** (Arabic)
   - If current language is Arabic, you should see: **EN** (English)

3. **Click the language button** to switch between English and Arabic
   - The page should reload
   - All text should change to the selected language

## What to Look For

### English (Default):
- Navigation: "Home", "Categories", "Carpets"
- Page title: "Home"
- Welcome message: "Welcome to your carpet inventory management system"
- Stats: "Total Products", "Total Units", "Total Value"
- Buttons: "Add New Carpet", "Edit", "Details"
- Units: "Units", "Meters", "Square Meters", "EGP"

### Arabic (After switching):
- Navigation: "الصفحة الرئيسية", "الفئات", "السجاد"
- Page title: "الصفحة الرئيسية"
- Welcome message: "مرحباً بك في نظام إدارة مخزون السجاد"
- Stats: "إجمالي المنتجات", "إجمالي الوحدات", "القيمة الإجمالية"
- Buttons: "إضافة سجادة جديدة", "تعديل", "التفاصيل"
- Units: "وحدات", "متر", "متر مربع", "جنيه"

## Troubleshooting

### If language doesn't switch:

1. **Check Browser Console** (Press F12)
   - Look for any JavaScript errors
   - Check Network tab to see if `/Culture/Set` endpoint is being called

2. **Check Browser Cookies**
   - Open Developer Tools → Application → Cookies
   - Look for `.AspNetCore.Culture` cookie
   - Value should be like: `c=ar|uic=ar` for Arabic or `c=en|uic=en` for English

3. **Clear Browser Cache**
   - Sometimes cached content can prevent updates
   - Try hard refresh: Ctrl+Shift+R (Windows) or Cmd+Shift+R (Mac)

4. **Check Resource Files**
   - Navigate to `Application/Resources/` folder
   - Verify all 6 files exist:
     - SharedResources.resx
     - SharedResources.ar.resx
     - SharedResources.Designer.cs
     - ValidationMessages.resx
     - ValidationMessages.ar.resx
     - ValidationMessages.Designer.cs

### Still Not Working?

The resources are embedded in the Application.dll. After building, you can verify:

```powershell
cd E:\SelfStydy\Elhmed\segad-elhmd
dotnet build
```

Then check the DLL was built with resources:
- Location: `Application\bin\Debug\net9.0\Application.dll`
- The .resx files should be embedded as resources

## Current Status

✅ Resource files created (English + Arabic)
✅ IStringLocalizer configured in all pages
✅ CultureController created for cookie management
✅ RequestLocalizationMiddleware configured
✅ Application builds successfully
✅ Application is running

## Pages Updated with Localization

- ✅ NavMenu (Navigation)
- ✅ Home page
- ✅ Carpets page
- ⚠️ Categories page (not yet updated)
- ⚠️ Form pages (CreateCarpet, EditCarpet, etc. - not yet updated)

## Next Steps if Everything Works

1. Update Categories page with localization
2. Update all form pages (Create/Edit Carpet, Create/Edit Category)
3. Add RTL (Right-to-Left) styling for Arabic
4. Test validation messages appear in correct language

---

**Note**: The application is currently running in the terminal. To stop it, press Ctrl+C in the terminal.
