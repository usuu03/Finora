using System;

namespace Finora.Domain.Entities;

public class SpendingCategory
{

}

// | Column      | Type     | Notes            |
// | ----------- | -------- | ---------------- |
// | `Id`        | Guid     |                  |
// | `UserId`    | Guid     | FK to `User`     |
// | `Name`      | string   | e.g. “Groceries” |
// | `Budget`    | decimal  | Monthly limit    |
// | `CreatedAt` | DateTime |                  |
