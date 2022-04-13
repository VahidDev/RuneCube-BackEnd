using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModels.Dtos.SettingDtos;
using DomainModels.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.DAL;

namespace RuneCube.DbSeeder
{
    public class DataInitializer
    {
        private AppDbContext _context;
        public DataInitializer(AppDbContext dbContext)
        {
            _context = dbContext;
        }
        public async Task InitializeDataAsync()
        {
            _context.Database.Migrate();
            if (!await _context.Stories.AnyAsync())
            {
                await _context.Stories.AddAsync(new Story
                {
                    StoryStartPrompt = "My best friend and I were wandering around a scary house when we accidentally dropped our phones in the basement. We were frustrated and scared, so we decided to use the mysterious magic cube to escape. The cube turned out to be authentic and we were able to find our way out!",
                    StoryEndPrompt = "Your friend and you escaped the spooky house safely! You both had a lot of courage and smarts to get out of there unharmed. It was a close call, but you managed to come out on top. Congrats!"
                });

                await _context.Stories.AddAsync(new Story
                {
                    StoryStartPrompt = "My friend and I were lost on Mars, and we found a mysterious magic cube. We tried to use it to escape teleportation to our world, but it didn't work. Then, we realized that we needed to use the magic cube to escape directly to our world. So, we did. We're safe now.Thanks, magic cube!",
                    StoryEndPrompt = "Your friend set the controls for the escape pod and you were the last two people to board. As you were climbing into the pod, you knew that this was your chance to get off the planet. The escape pod propelled you away from the planet and into the safety of space. You and your friend completed the mission and you are one step closer to finding a new home for humanity. Congratulations!"
                });
                await _context.Stories.AddAsync(new Story
                {
                    StoryStartPrompt = "You and your friend were hiking through a dark and spooky forest when you discovered a strange looking cube. When you touched it, it activated and transported you both inside. You're now lost and terrified, with no idea how you arrived here. If you can use the cube to escape, you'll be safe - but you'll have to be quick because the forest is getting darker and more ominous by the minute.",
                    StoryEndPrompt = "Many thanks to the both of you for all of your hard work in getting out of the forest safely. It was truly a team effort and I'm so happy that you both made it out alive. Congratulations on making it out!"
                });
                await _context.Stories.AddAsync(new Story
                {
                    StoryStartPrompt = "You are both scared and you have no idea how you bot appeared here. You each reach for the magic cube, ready to use it to escape. Suddenly, the cube Beverly starts flashing and a loud noise ensues. You look around, seeing that the forest has disappeared and you're now in another strange place.",
                    StoryEndPrompt = "You and your friend successfully escaped the forest! I'm so glad you made it out alive! Hooray!"
                });
                await _context.Stories.AddAsync(new Story
                {
                    StoryStartPrompt = "Your friend and you are lost on the planet Mars. A mysterious magic cube leads you to believe that you can escape to your world through teleportation. However, the cube only works when the three colors are combined. You must choose wisely as to which colors to use, as wrong choices will result in death.",
                    StoryEndPrompt = "You and your friend had been planning your escape for months, and finally it was finally going to happen. You and your friend were making your way through the dense Martian atmosphere, when suddenly something went wrong. You lost control of your ship, and before you knew it you were crashing into the planet surface. But luckily, you and your friend survived, and now you can safely return home. congratulations!"
                });
            }
            if(!await _context.Runes.AnyAsync())
            {
                await _context.Runes.AddRangeAsync(new List<Rune> { 
                new Rune{Value="Cylinder"},
                new Rune{Value="Torus"},
                new Rune{Value="Box"},
                new Rune{Value="Sphere"},
                });
            }
            if(!await _context.Settings.AnyAsync())
            {
                int time = 15;
                Setting setting = new();
                setting.MaxResponseTime = time;
                setting.Count = 5;
                setting.EachSideCount = 3;
                setting.SidesTime = time * setting.Count;
                await _context.Settings.AddAsync(setting);
            }
            await _context.SaveChangesAsync();

        }
    }
}
