# RPG Game on Unity 2D
Проект заключается в том, чтобы разработать игру жанра RPG(Role play game) на unity с 2D Top down пиксельной графикой.
Игра будет состоять из механик классических игр жанра RPG: прокачка персонажа, исследование, выполнение квестов, сюжет, боевая система, основанная на прокаченных навыках героя, а также крафт и торговля.


## Подключения сриптов C++ к Unity

    1. В Visual Studio(На данный момент 2019) создать проект "Библиотека динамической компоновки"
    2. Правой кнопкой нажать на "Исходные файлы">Добавить>Создать элемент>Файл C++
    3. Также нажатием на файлы заголовков создать файл заголовка(.h)
    4. В новый файл C++ внести нужные функции, а также include "pch.h"
    5. В файл заголовка добавит:
```C++
#ifndef FIRSTDLL_NATIVE_LIB_H
#define FIRSTDLL_NATIVE_LIB_H

#define DLLExport __declspec(dllexport)

extern "C"
{
    DLLExport тип_функции название_функции(...);
    ...
    DLLExport тип_функции название_функции(...);
}
#endif
```
    6. В pch.h добавить свой файл заголовка: include  "название_header.h"
    7. Выбрать Realese x64 перед сборкой и нажать Сборка>Собрать решение.
    8. Перенести из папки C:\Users\имя\source\repos\Название_проекта\x64\Release .dll в папку проекта Unity
    9. В Unity создаем новый скрипт, в нем пишем:
```C++
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;


public class Название_Скрипта : MonoBehaviour
{
    // Start is called before the first frame update
    [DllImport("Название_DLL")]
    public static extern тип_функции название_функции(...);
    ...
    [DllImport("Название_DLL")]
    public static extern тип_функции название_функции(...);


    void Start()
    {
        Debug.Log(название_функции(...)); //Выведет в Console Unity возвращаемое значение(Нужно для проверки работоспособности)
    
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
```

Почти такая же инструкция, только с картинками, есть на stackoverlow: https://stackoverflow.com/questions/49793560/build-c-plugin-for-unity
