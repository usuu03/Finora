using System;

namespace Finora.Domain.Entities;

public class Goal
{

}

// | Column          | Type     | Notes                  |
// | --------------- | -------- | ---------------------- |
// | `Id`            | Guid     |                        |
// | `UserId`        | Guid     | FK to `User`           |
// | `Title`         | string   | “Buy House”            |
// | `TargetAmount`  | decimal  | e.g. £20,000           |
// | `CurrentAmount` | decimal  | Optional manual input  |
// | `Deadline`      | DateTime | When to reach the goal |
// | `CreatedAt`     | DateTime |                        |
