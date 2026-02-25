# ASP.NETCoreSD46IsmailiaD05

# 🔷 ASP.NET Core MVC – State Management & Model Binding (.NET 9)

This project demonstrates **State Management & Model Binding**:

- ✅ ASP.NET Core **State Management**
  - TempData
  - Session
  - Cookies
- ✅ ASP.NET Core **Model Binding**
  - Primitive Types
  - Arrays
  - Collections
  - Complex Types
  - Bind Attribute
  - FromRoute & FromQuery

---

# 📌 State Management

State Management allows you to store and retrieve data across HTTP requests.

---

## 1️⃣ TempData

### 🔹 Definition
- Stores data for **one redirect request**
- Uses Session internally
- Automatically removes data after it is read (unless kept)

### ✅ Example

```csharp
public IActionResult SetTempData()
{
    TempData["Message"] = "Hello from TempData";
    return Content("TempData Saved");
}
```

### 🔹 Normal Read (Removes Data)

```csharp
public IActionResult GetTempData1()
{
    string? message = TempData["Message"]?.ToString();
    return Content(message ?? "No message");
}
```

### 🔹 Peek (Does NOT Remove)

```csharp
string? message = TempData.Peek("Message")?.ToString();
```

### 🔹 Keep (Preserve After Read)

```csharp
string? message = TempData["Message"]?.ToString();
TempData.Keep("Message");
```

---

## 2️⃣ Session

### 🔹 Definition
- Stores data until session expires
- Stored server-side
- Requires Session middleware

### ✅ Example

```csharp
public IActionResult SetSession()
{
    HttpContext.Session.SetString("Message", "Hello from Session");
    HttpContext.Session.SetInt32("Age", 42);
    return Content("Session Saved");
}
```

```csharp
public IActionResult GetSession()
{
    string? message = HttpContext.Session.GetString("Message");
    int? age = HttpContext.Session.GetInt32("Age");
    return Content($"Message: {message}, Age: {age}");
}
```

---

## 3️⃣ Cookies

### 🔹 Definition
- Stored client-side (Browser)
- Can have expiration time
- Can be HttpOnly (secure)

### ✅ Example

```csharp
public IActionResult SetCookie()
{
    CookieOptions cookieOptions = new CookieOptions
    {
        Expires = DateTimeOffset.UtcNow.AddHours(10),
        HttpOnly = true,
        IsEssential = true
    };

    Response.Cookies.Append("Message", "Hello From Cookie", cookieOptions);
    return Content("Cookie Saved");
}
```

```csharp
public IActionResult GetCookie()
{
    string? message = Request.Cookies["Message"];
    return Content($"Message: {message}");
}
```

---

# 📌 Model Binding

## 🔹 Definition

Model Binding maps data from:
- Route
- Query String
- Form Data
- Body

Into action method parameters automatically.

---

# 1️⃣ Primitive Model Binding

### Example 1

URL:
```
~/ModelBinding/PrimitiveModelBinding1?id=42
```

```csharp
public IActionResult PrimitiveModelBinding1(int id)
{
    return Content($"Received Id: {id}");
}
```

---

### Example 2 (Different Parameter Name)

```
~/ModelBinding/PrimitiveModelBinding2?empId=42
```

```csharp
public IActionResult PrimitiveModelBinding2(int empId)
{
    return Content($"Received Id: {empId}");
}
```

---

# 2️⃣ Multiple Parameters

```
~/ModelBinding/PrimitiveModelBinding3?empId=42&name=Ahmed
```

```csharp
public IActionResult PrimitiveModelBinding3(int empId, string name)
{
    return Content($"Received Id: {empId}, Name: {name}");
}
```

---

# 3️⃣ Array Model Binding

```
~/ModelBinding/ArrayModelBinding4?empId=45&colors=red&colors=blue
```

```csharp
public IActionResult ArrayModelBinding4(int empId, string[] colors)
{
    return Content($"Received Id: {empId}, Colors: {string.Join(", ", colors)}");
}
```

---

# 4️⃣ Dictionary / Collection Binding

```
~/ModelBinding/CollectionsModelBinding5?phones[ahmed]=12&phones[ali]=456
```

```csharp
public IActionResult CollectionsModelBinding5(Dictionary<string, int> phones)
{
    return Content($"Received Phones: {string.Join(", ", phones.Select(p => $"{p.Key}: {p.Value}"))}");
}
```

---

# 5️⃣ Complex Type Model Binding

### Department Model

```csharp
public class Department
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public virtual ICollection<Employee> Employees { get; set; }
        = new HashSet<Employee>();
}
```

---

### Example

```
~/ModelBinding/ComplexModelBinding5?id=5&name=HR
```

```csharp
public IActionResult ComplexModelBinding5(Department department)
{
    return Content($"Received Department: {department.Name}, Id: {department.Id}");
}
```

---

# 6️⃣ Nested Complex Model Binding

```
~/ModelBinding/ComplexModelBinding7?id=5&name=HR&employees[0].name=Ahmed
```

Model binder automatically binds nested Employees collection.

---

# 7️⃣ Bind Attribute (Security)

Prevents Over-Posting Attack

```csharp
public IActionResult ComplexModelBinding8(
    [Bind(include:"Id, Name")] Department department)
{
    return Content($"Received Department: {department.Name}");
}
```

---

# 8️⃣ FromRoute

```csharp
public IActionResult PrimitiveModelBinding9([FromRoute] int id)
{
    return Content($"Received Id: {id}");
}
```

---

# 9️⃣ FromQuery

```csharp
public IActionResult PrimitiveModelBinding10([FromQuery] int id)
{
    return Content($"Received Id: {id}");
}
```

---

# 🔥 Key Learning Points

✅ TempData → One redirect only  
✅ Session → Stored until session expires  
✅ Cookies → Stored in browser  
✅ Model Binding automatically maps request data  
✅ Supports primitive, array, dictionary & complex types  
✅ [Bind] prevents over-posting  
✅ [FromRoute] & [FromQuery] control binding source  

---

# 🧠 Summary

ASP.NET Core provides:

- Powerful state management options
- Automatic model binding
- Clean controller actions
- Strong typing without manual parsing

This project demonstrates how HTTP request data flows into action methods and how state is preserved across requests.

---

# 👨‍💻 Author

Mohamed Hatem  
Software Engineer

---
