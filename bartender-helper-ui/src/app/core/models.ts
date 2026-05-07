export interface AuthResponse {
  username: string;
  token: string;
}

export interface CocktailSummary {
  id: number;
  name: string;
  description: string;
  glassType: string;
  isCanonical: boolean;
  ownerId: number | null;
  ownerUsername: string | null;
}

export interface CocktailDetail {
  id: number;
  name: string;
  description: string;
  instructions: string;
  glassType: string;
  imageUrl: string | null;
  isCanonical: boolean;
  ownerId: number | null;
  ownerUsername: string | null;
  ingredients: Ingredient[];
}

export interface Ingredient {
  id: number;
  name: string;
  amount: string;
  unit: string | null;
}

export interface IngredientRequest {
  name: string;
  amount: string;
  unit: string | null;
}

export interface SaveCocktailRequest {
  name: string;
  description: string;
  instructions: string;
  glassType: string;
  imageUrl: string | null;
  ingredients: IngredientRequest[];
}
