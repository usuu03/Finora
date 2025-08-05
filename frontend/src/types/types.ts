export type Transaction = {
  id: string;
  amount: number;
  category: string;
  description: string;
  type: "Income" | "Expense" | "TopUp";
  date: string;
  createdAt: string;
};
