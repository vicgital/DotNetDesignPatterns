# .NET Design Patterns


## SOLID PRinciples

### **Single Responsibility Principle (SRP)**

The **Single Responsibility Principle (SRP)** is one of the five SOLID principles in Object-Oriented Programming (OOP). It states:  

> **"A class should have only one reason to change."**

This means that a class should focus on a single responsibility or functionality. It should encapsulate behaviors that are closely related, ensuring that each class has a clear and narrow purpose.

---

### **Open-Closed Principle (OCP)**

The Open-Closed Principle (OCP) is one of the SOLID principles in object-oriented programming. It states that:

> **"Software entities (classes, modules, functions, etc.) should be open for extension, but closed for modification."**

This means that the behavior of a module can be extended without modifying its source code, making it easier to maintain and scale without introducing bugs in existing functionality.

---

### **Liskov Substitution Principle (LSP)**

The Liskov Substitution Principle (LSP) is one of the five SOLID principles of object-oriented design. It states:

> **"Objects of a superclass should be replaceable with objects of a subclass without altering the correctness of the program."**

This principle ensures that a subclass can stand in for its superclass without unexpected behaviors. Violating LSP often leads to fragile and unpredictable code.

#### Key Points
- Subclasses should not override or change the behavior of the base class in a way that breaks the base class's contract.
- Consumers of the base class should be able to use the subclass without knowing the difference.
- A subclass must adhere to the behavior expected by the superclass.


---

### **Interface Segregation Principle (ISP)**

The **Interface Segregation Principle (ISP)** states that a class should not be forced to implement interfaces it does not use. Instead, interfaces should be divided into smaller, more specific ones to ensure that implementing classes only need to be concerned with the methods that are relevant to them.

#### Definition
> **"Clients should not be forced to depend on methods they do not use."**

This principle aims to avoid creating large, monolithic interfaces and encourages the design of small, role-specific interfaces.

---

### **Dependency Inversion Principle (DIP)**

The Dependency Inversion Principle (DIP) is one of the SOLID principles in object-oriented design. It states:

> 1. **High-level modules should not depend on low-level modules. Both should depend on abstractions.**
> 2. **Abstractions should not depend on details. Details should depend on abstractions.**


This principle ensures that the high-level policy of a system does not depend on the details of the low-level implementation. It promotes decoupling and makes the system more flexible and easier to maintain.






