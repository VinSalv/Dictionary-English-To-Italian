# Dictionary English to Italian
Implementation of dictionary English to Italian by using MySQL, WindowsForms and Visual Studio IDE.

## Paths
```
|-- DictionaryEngToIt
|   |-- Sources
|   |   |-- MainForm.cs
|   |   |-- AddForm.cs
|   |   |-- Word.cs
|   |   |-- Phrase.cs
|   |   |-- Utils.cs
|   |   |-- DataAccessLayer.cs
|   |   |-- DataAccessLayerQuery.cs
|   |-- Forms
|   |   |-- MainForm.Designer.cs
|   |   |-- AddForm.Designer.cs
|   |-- Program.cs
|   |-- Init Database.sql
```

It has been realized by:
- MainForm: show the list of phrases/words
- AddForm: add and edit phrases/words
- Word: object Word
- Phrase: object Phrase
- Utils: constants and functions useful for other classes
- DataAccessLayer: Singleton connection to MySQL database
- DataAccessLayerQuery: queries database (backend)
- Init Database: init tables, users and triggers in MySQL

# Interface

### DictionaryEngToIt
<p align="center">
 <img src="https://user-images.githubusercontent.com/45711698/232349939-1e49e9f0-bb47-42ba-8bad-e0c49e0776ec.png" />
</p>

### Phrases
<p align="center">
 <img src="https://user-images.githubusercontent.com/45711698/232349955-522fc0df-5663-4d9a-81d0-b2aa336f146f.png" />
</p>

### Words
<p align="center">
 <img src="https://user-images.githubusercontent.com/45711698/232349978-f08ce111-5e8c-4285-abdf-4bceb9053a38.png" />
</p>

<p align="center">
 <img src="https://user-images.githubusercontent.com/45711698/232350127-eb852a5d-4306-4c0f-b771-1a007b92f2cb.png" />
</p>

<p align="center">
 <img src="https://user-images.githubusercontent.com/45711698/232350132-3f5904ec-ef5a-4c0d-881f-af5af288aee6.png" />
</p>

<p align="center">
 <img src="https://user-images.githubusercontent.com/45711698/232350134-52806917-c0f1-4b19-8078-35bc4d0d260f.png" />
</p>

### Add
<p align="center">
 <img src="https://user-images.githubusercontent.com/45711698/232350216-a9fb69f8-3371-439b-8210-d26dd91db180.png" />
</p>

### Edit
<p align="center">
 <img src="https://user-images.githubusercontent.com/45711698/232350240-a17c1aba-86d7-4c8f-a5d5-3778130e1253.png" />
</p>

<p align="center">
 <img src="https://user-images.githubusercontent.com/45711698/232350258-6445cf5d-f3d3-4a5e-8adb-5f4143123ec6.png" />
</p>

### About the creator
<p align="center">
 <img src="https://user-images.githubusercontent.com/45711698/232350257-2d1f68fa-4094-439b-a83d-bb82e0fc90d6.png" />
</p>

# MySQL scheme

<p align="center">
 <img src="https://user-images.githubusercontent.com/45711698/232353334-5a6537e9-4966-46f4-adba-e156878a67bf.png" />
</p>
