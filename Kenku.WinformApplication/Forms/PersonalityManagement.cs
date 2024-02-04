using Kenku.Models.Implementations;
using Kenku.Models.Interfaces;
using System.ComponentModel;

namespace Kenku.WinformApplication.Forms
{
    public partial class PersonalityManagement : Form
    {
        public PersonalityManagement() { this.InitializeComponent(); }
        public PersonalityManagement(IReadOnlyList<IReadOnlyPersonality> personalities) : this()
        {
            this.Personalities = new BindingList<Personality>(personalities
                .Select(x => (x as Personality) ?? new Personality()
                {
                    Name = x.Name,
                    Description = x.Description
                }).ToList());
            this.PersonalityListBox.DisplayMember = "Name";
            this.PersonalityListBox.DataSource = this.Personalities;
        }

        private void PersonalityListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.PersonalityListBox.SelectedItem is IReadOnlyPersonality personality)
            {
                this.PersonalityNameTextBox.Text = personality.Name;
                this.PersonalityDescriptionTextBox.Text = personality.Description;
            }
        }

        private void AddCommand_Click(object sender, EventArgs e)
        {
            var newItem = new Personality()
            {
                Id = Guid.NewGuid(),
                Name = "New",
                Description = "Description"
            };
            this.Personalities
                .Add(newItem);
            this.PersonalityListBox.SelectedItem = newItem;
        }

        private void DeleteCommand_Click(object sender, EventArgs e)
        {
            if (this.PersonalityListBox.SelectedItem is Personality personality)
            {
                this.Personalities
                    .Remove(personality);
            }
        }

        private void OkCommand_Click(object sender, EventArgs e) => this.DialogResult = DialogResult.OK;

        private void PersonalityNameTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.PersonalityListBox.SelectedItem is Personality personality)
            {
                personality.Name = this.PersonalityNameTextBox.Text;
            }
        }

        private void PersonalityDescriptionTextBox_TextChanged(object sender, EventArgs e)
        {
            if (this.PersonalityListBox.SelectedItem is Personality personality)
            {
                personality.Description = this.PersonalityDescriptionTextBox.Text;
            }
        }

        private BindingList<Personality> Personalities { get; set; }

        public IReadOnlyList<IReadOnlyPersonality> EditedPersonalities => this
            .Personalities
            .ToList();
    }
}