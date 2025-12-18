# Git Setup & Push Instructions

## ✅ Local Repository Created

Your project is now tracked with Git locally:
- ✅ Git initialized
- ✅ .gitignore configured
- ✅ README.md created
- ✅ 88 files committed

## 📤 Push to GitHub

### Option 1: Using GitHub CLI (Recommended)
```powershell
# Install GitHub CLI if not already installed
# Download from: https://cli.github.com/

# Login to GitHub
gh auth login

# Create and push repository
gh repo create segad-elhmd --public --source=. --remote=origin --push
```

### Option 2: Using Git Commands

**Step 1: Create repository on GitHub**
1. Go to https://github.com/new
2. Repository name: `segad-elhmd`
3. Description: "Blazor Carpet Management System with Clean Architecture & CQRS"
4. Choose Public or Private
5. **Do NOT** initialize with README (we already have one)
6. Click "Create repository"

**Step 2: Connect and push**
```powershell
cd e:\SelfStydy\Elhmed\segad-elhmd

# Add remote (replace YOUR_USERNAME with your GitHub username)
git remote add origin https://github.com/YOUR_USERNAME/segad-elhmd.git

# Rename branch to main (GitHub default)
git branch -M main

# Push to GitHub
git push -u origin main
```

## 📤 Push to GitLab

### Create repository on GitLab
1. Go to https://gitlab.com/projects/new
2. Project name: `segad-elhmd`
3. Visibility: Public or Private
4. **Uncheck** "Initialize repository with a README"
5. Click "Create project"

### Connect and push
```powershell
cd e:\SelfStydy\Elhmed\segad-elhmd

# Add remote (replace YOUR_USERNAME with your GitLab username)
git remote add origin https://gitlab.com/YOUR_USERNAME/segad-elhmd.git

# Rename branch to main
git branch -M main

# Push to GitLab
git push -u origin main
```

## 🔐 SSH Authentication (Optional but Recommended)

### Generate SSH Key
```powershell
ssh-keygen -t ed25519 -C "your_email@example.com"
```

### Add SSH key to GitHub
```powershell
# Copy public key to clipboard
Get-Content ~/.ssh/id_ed25519.pub | Set-Clipboard

# Or display it
cat ~/.ssh/id_ed25519.pub
```

Then:
1. Go to GitHub Settings → SSH and GPG keys → New SSH key
2. Paste the key and save

### Use SSH remote instead
```powershell
# For GitHub
git remote set-url origin git@github.com:YOUR_USERNAME/segad-elhmd.git

# For GitLab
git remote set-url origin git@gitlab.com:YOUR_USERNAME/segad-elhmd.git
```

## 🔄 Making Changes Later

```powershell
# Check status
git status

# Stage changes
git add .

# Commit
git commit -m "Your commit message"

# Push to remote
git push
```

## 📝 Useful Git Commands

```powershell
# View commit history
git log --oneline

# View remote URL
git remote -v

# Create new branch
git checkout -b feature/new-feature

# Switch branches
git checkout main

# Pull latest changes
git pull origin main
```

## 🌟 What's Committed

Your repository includes:
- ✅ Clean Architecture structure (Domain, Application, Infrastructure)
- ✅ CQRS with MediatR implementation
- ✅ All Blazor components and pages
- ✅ Comprehensive README.md
- ✅ Architecture documentation
- ✅ AI agent instructions (.github/copilot-instructions.md)
- ✅ Docker support
- ✅ Bootstrap UI framework

**Note:** Binary files (bin/, obj/) are excluded via .gitignore

---
Happy coding! 🚀
