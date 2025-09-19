# Contributing to BudgetWise

Thank you for considering contributing! 🎉

---

## 🌳 Branching Workflow
- Base your work on `dev` branch.
- Use short-lived feature branches:
  ```
  feat/<scope>-<short-desc>
  fix/<scope>-<short-desc>
  chore/<scope>-<short-desc>
  ```
- Open Pull Requests (PRs) into `dev` only.

---

## 📝 Commit Messages
We follow [Conventional Commits](https://www.conventionalcommits.org/):

```
<type>(scope?): message
```

**Examples:**
- `feat(api): add budgets endpoint`
- `fix(core): correct rounding bug in forecast`
- `chore(deps): update EF Core to 9.0.1`

Types: `feat`, `fix`, `docs`, `chore`, `refactor`, `test`, `perf`.

---

## ✅ PR Checklist
Before opening a PR:
- [ ] Code builds locally (`dotnet build -c Release`)
- [ ] Tests added/updated (`dotnet test -c Release`)
- [ ] Breaking changes documented in `README.md` or changelog
- [ ] PR uses meaningful title and description

---

## 🔍 Reviews
- At least 1 approval required before merge.
- Stale approvals are dismissed if new commits are pushed.

---

## 🧪 Tests
- Place unit tests in `tests/Tests`
- Follow AAA (Arrange-Act-Assert) style
- Keep tests independent and deterministic

---

## 📦 Dependencies
- Manage NuGet via project files
- Don’t commit secrets — use `.env` (git-ignored) and AWS Secrets Manager
