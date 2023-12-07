List<string> inputs = new List<string>();
using (StreamReader reader = new StreamReader(args[0]))
{
    while (!reader.EndOfStream)
    {
        inputs.Add(reader.ReadLine());
    }
}

part1();
part2();

void part1()
{
    int runTotal = 0;

    int red_max = 12;
    int green_max = 13;
    int blue_max = 14;

    foreach (var item in inputs)
    {
        List<string> elfSplit = item.Split(':').ToList<string>();

        string? game = elfSplit[0];
        string? bag = elfSplit[1];

        List<string> rounds = bag.Split(';').ToList<string>();

        bool failed = false;

        foreach (var round in rounds)
        {
            List<string> color_cnt = round.Split(',').ToList<string>();
            foreach (var colorA in color_cnt)
            {
                string color = colorA.Split(' ')[2];
                int cnt = Convert.ToInt32(colorA.Split(' ')[1]);
                if (color == "red" && cnt > red_max)
                    failed= true;
                if (color == "green" && cnt > green_max)
                    failed = true;
                if (color == "blue" && cnt > blue_max)
                    failed = true;
            }
        }
        if(!failed)runTotal += int.Parse(game.Split(' ')[1]);
    }
    Console.WriteLine(runTotal);
}

void part2()
{
    int runTotal = 0;

    foreach (var item in inputs)
    {
        List<string> elfSplit = item.Split(':').ToList<string>();

        string? game = elfSplit[0];
        string? bag = elfSplit[1];

        List<string> rounds = bag.Split(';').ToList<string>();
        int red_now = 0;
        int blue_now = 0;
        int green_now = 0;
        foreach (var round in rounds)
        {
            List<string> color_cnt = round.Split(',').ToList<string>();
            foreach (var colorA in color_cnt)
            {
                string color = colorA.Split(' ')[2];
                int cnt = Convert.ToInt32(colorA.Split(' ')[1]);
                if (color == "red" && cnt > red_now)
                    red_now = cnt;
                if (color == "green" && cnt > green_now)
                    green_now = cnt;
                if (color == "blue" && cnt > blue_now)
                    blue_now = cnt;
            }
        }
        runTotal += red_now * green_now * blue_now;
    }
    Console.WriteLine(runTotal);
}