using System.IO;
var watch = new System.Diagnostics.Stopwatch();
            
string fileName = @"byteOutput.txt";

watch.Start();
/* Some things to try an do
NEED TO DO MAKE IT SO BYTE COUNT WORKS PROPERLY WTFFFFF
    Create the permutator follow only the manchesters rule - meaning no vit can appear 3 consecutive times in a tow
    Figure out a more efficient brute forcing technique - DUH
*/

//all permutation of single byte
//EX: 1: 00000000 -> 00000001 -> 00000010 -> 00000100...11111111
Console.WriteLine("How many bytes ya want: ");
string inp = Console.ReadLine();
int byteCount = Int32.Parse(inp);

string[] bytes = getCombinations();
using(StreamWriter writer = new StreamWriter(fileName)){
    for(int  i = 0; i < bytes.Length; i++){
        string fatherByte = bytes[i];
        for(int x = 0; x < bytes.Length; x++){
            Console.WriteLine(bytes[i] + bytes[x]);
            writer.WriteLine(bytes[i] + bytes[x]);
        }
    }
}
ManchesterOrganize();
watch.Stop();

Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");

static string[] getCombinations(){
    string[] combs = new string[256];
    for(int x = 0; x < 256; x++){
        string curByte = Convert.ToString(x, 2).PadLeft(8, '0');
        combs[x] = curByte;
    }
    return combs;
}

static bool ManchesterOrganize(){
    string fileName = @"byteOutput.txt";
    string path = @"manchesterOutput.txt";
    string[] bytes = File.ReadAllLines(fileName);
    int byteLen = 0;
    if(bytes.Length != 0) { byteLen = bytes[0].Length;}
    using(StreamWriter sw = new StreamWriter(path)){
        for(int x = 0; x < bytes.Length; x++){
            //lex the char to see if 
            string curByte = bytes[x];
            char[] charArr = curByte.ToCharArray();
            bool validByte = true;
            for(int i = 1; i < byteLen-1; i++){
                if(charArr[i] == charArr[i-1] && charArr[i] == charArr[i+1]){
                    validByte = false;
                }
            }
            if(validByte){
                    sw.WriteLine(curByte);
            }
        }
    }
    Console.WriteLine("[!] Manchester Organization Completed");
    return true;
}