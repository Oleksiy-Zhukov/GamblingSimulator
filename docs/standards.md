# CSCI 265 Team Standards and Processes (Phase 2)

## Team name: Section 3

## Project/product name: Gambling Simulator

## Key contact person and email

 * Josiah Bowden, josiahbowden4@gmail.com *main contact*

## Documentation standards and processes
Documents is a critical component of our project as it ensure that all aspects of the development process are clearly communicated and maintained. This section outlines the standards and processes we will follow for project documentation, such as the Charter, Proposal, Standards, Requirements, and Design documents.

**Standards**:
* Use the [Markdown](https://www.markdownguide.org/basic-syntax/) format for internal documentation and project structure docs. This provides a simple and clean format for easy collaboration and version control.
* Collaboration Platform: The team will use Google Docs and Google Drive to collaborate on documents. This allows multiple team members to work on the same document simultaneously, ensuring efficient teamwork.
* Assignment: At times, specific documents or sections may be assigned to individual team members to streamline the writing process. Once completed, the document or section will be reviewed by the rest of the team.
* For grammar and style, use [Grammarly](https://www.grammarly.com/) or a built-in spell checker in your code editor (like Visual Studio’s editor tool or Microsoft Docs editor tool).

**Process**:
Team members collaborate on Google Docs to draft and revise documents in real-time. Each document (e.g., Charter, Requirements, Design) will have an assigned lead writer who is responsible for coordinating feedback and ensuring the document adheres to standards. If the document is assigned to a specific person, that individual is responsible for writing and delivering it for review.

**Enforcement**:

* Each team member is responsible for their assigned section as they write it.
* Weekly meetings will include a review of any pending documents to make sure they are progressing and meeting the necessary standards.

**Review Process**:
Peer reviews of documents are mandatory. Documents will not be considered final until they are reviewed by at least one other team member.
* Use a “definition of done” checklist for documentation, ensuring:
    * Clear descriptions.
    * Consistent formatting.
    * Spelling and grammar checks.

## Coding standards and processes
This section details the standards and processes for writing, reviewing, and maintaining code throughout the development lifecycle. 

**Standards**:
* Follow the [C# Coding Conventions](https://learn.microsoft.com/en-us/dotnet/csharp/fundamentals/coding-style/identifier-names) as a baseline.
* Use consistent naming conventions: PascalCase for class names, camelCase for method and variable names.
* Always include access modifiers (e.g., `public`, `private`).

**Process**:
* All code changes will be developed in feature branches, with peer reviews required before merging into the development branch. The main branch will only contain thoroughly tested and approved code.
* Every feature should have associated unit test where applicable. Use [Unity Test Framework](https://docs.unity3d.com/Packages/com.unity.test-framework@1.1/manual/index.html) for testing Unity scripts.

**Enforcement**:
Peer code reviews will be mandatory before any code is merged into the main branch. A code reviewer will be assigned for each pull request. All pull requests must meet testing and coding standards before approval.

**Review Process**:
Code reviews will focus on adherence to coding standards, test coverage, and design consistency. The team's Dev Lead (Oleksii Zhukov) is responsible for overseeing the overall quality of the codebase and ensuring that peer reviews are properly conducted.

## Version control standards and processes
Version control is essential for managing changes in the project’s codebase and documentation. This section outlines the structure and processes for maintaining the repository using Git, ensuring smooth collaboration and efficient tracking of changes.

**Repo Structure**:
* /src: Main source code for the project.
* /docs: All project documentation.
* /test: Unit and intergration tests.

**Branches**:
* Main: This is the production-ready branch. Only thoroughly tested and approved code will be merged here.
* Dev: Development branch for ongoing features and bug fixes.
* Feature branches: Each feature or bug fix will be developed on a separate branch. Feature branches will be merged into Dev after review.

**Commit Messages**:
* Use a consistent format for commit messages:
    * `feat`: for new features (e.g., `feat: add blackjack game mode`).
    * `fix`: for bug fixes (e.g., `fix: resolve game state reset issue`).
    * `docs`: for documentation changes.
    * `test`: for adding or improving tests.
    * `refactor`: for code refactoring without changing functionality.

**Tagging Releases**:
* Use semantic versioning (vX.Y.Z) for tagging releases (e.g., v1.0.0).

**Pull Requests**:
Pull requests will be reviewed by at least one other team member, and the team’s Git Lead will be responsible for approving or merging them. Team members are responsible for including a detailed summary in each pull request, referencing any related issues or documentation.
* Git Lead: Oleksii Zhukov.

**Enforcement**:
Branch protection rules will be enforced on the main branch, meaning code must pass all tests and be approved through peer review before merging.

**Review Process**:
* Weekly meetings will be held to review the state of the repository, making sure branches are kept clean and unused branches are deleted.
* A Git Lead will be assigned to oversee the repository’s health and enforce version control rules.