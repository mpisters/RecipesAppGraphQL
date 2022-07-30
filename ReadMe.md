# Recipes App

### Run app

First build docker image
```bash
 docker build --no-cache -t app -f Dockerfile .
```
Run app on localhost:8080
```bash
 docker run -p 8080:80 -t -i app
```

### Migrations
```bash
dotnet ef migrations add Add<Name>
```

```bash
dotnet ef database update
```

### Grapql
```bash
 mutation {
  createIngredientForRecipeId(recipeId: 1, ingredientDto: {
    product: {name: "pasta"},
    amount: 250,
    unitOfMeasurement:G
  }){
    amount
  }
 }
```

```bash
 {  
   recipeById(id: 1) {
     name,
     ingredients{
       amount
       product {
         name
       },
       unitOfMeasurement
     }
   }
 }
```

```bash
mutation {
 createCompleteRecipe(createRecipeDto: {
   name: "pizza",
   ingredients: [
     {product: {
       name: "bodem"
     }, 
     amount: 1,
     unitOfMeasurement:UNIT
     },
     {product: {
       name: "tomaat"
     },
      amount: 10,
      unitOfMeasurement:UNIT
     }
   ]
   steps: [
     {
       description: "Maak de pizza saus."
     }
   ]
 }) {
   name
 }
}
```