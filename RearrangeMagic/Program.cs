using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rearrange_Magic
{
    public class Program
    {
        public static bool IsMagicSquare(List<int> square){
            int columns = Int32.Parse(Math.Sqrt(square.Count).ToString());
                
            int magicSum = 0;
            bool toReturn = true;
            
            int forwardDiagnal = 0; // => 0, 4, 8
            int backwardDiagnal = 0;// => 2, 4, 6
            
            for (int i = 0; i < columns; i++){
                int rowSum = 0;
                int columnSum = 0;
                for (int j = 0; j < columns; j++){
                    columnSum += square[(i * columns) + j];
                    rowSum += square[i + (j * columns)];
                }
                if (magicSum == 0)
                    magicSum = columnSum;
                if(columnSum != magicSum) 
                    toReturn = false;
                if (rowSum != magicSum)
                    toReturn = false;
                forwardDiagnal += square[i * columns + i];
                backwardDiagnal += square[(columns * (i + 1))- (i + 1)];
            }
            
            if (forwardDiagnal != magicSum)
                toReturn = false;
            if (backwardDiagnal != magicSum)
                toReturn = false;
                
            return toReturn;
        }
        
        public static List<int> FindMagicSquare(List<int> square){
            int c = int.Parse(Math.Sqrt(square.Count()).ToString());
            int x = 0;
            int y = 0;
            //int iterations = 0;
            Random r = new Random();
            Dictionary<string,bool> failed = new Dictionary<string,bool>();
            while (!IsMagicSquare(square))
            {
                //StringBuilder sbInner = new StringBuilder();
                //do {
                    y = r.Next(0, c);
                    do {
                        x = r.Next(0, c);
                    } while (x == y);
                    
                    //take out
                    List<int> sub = square.Skip(x * c).Take(c).ToList();
                    square.RemoveRange(x * c, c);
                    square.InsertRange(y * c, sub);
                    //sbInner = new StringBuilder();
                    //for (int j = 0; j < square.Count(); j++)
                        //sbInner.Append(square[j] + ", ");
                    //see if we did this already...
                //} while (failed.ContainsKey(sbInner.ToString()));
                
                /*StringBuilder sb = new StringBuilder();
                for (int j = 0; j < square.Count(); j++)
                    sb.Append(square[j] + ", ");
                failed[sb.ToString()] = false;*/
                
                //iterations++;
                //if ( iterations > 999 * 1000 * 1000)
                //    break;
                //Console.WriteLine(iterations +  " " + x + " "  + y + " - " + square.Count());
            }
            return square;
        }
        
        public static void RunTest(string input){
            
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            Console.WriteLine("working...");
            List<List<int>> magicSquare = new List<List<int>>();
            List<int> magicSquareAsLine = new List<int>();
            
            int i;
            input = input.Replace('\r', ' ');
            input = input.Replace('\n', ' ');
            foreach (var x in input.Split(' '))
                if (int.TryParse(x, out i))
                    magicSquareAsLine.Add(i);
                    
            magicSquareAsLine = FindMagicSquare(magicSquareAsLine);
            Console.WriteLine(IsMagicSquare(magicSquareAsLine));
            
            StringBuilder sb = new StringBuilder();
                for (int j = 0; j < magicSquareAsLine.Count(); j++)
                    sb.Append(magicSquareAsLine[j] + ", ");
            Console.WriteLine(sb.ToString());
            stopwatch.Stop();
            Console.WriteLine("Time took : " + stopwatch.ElapsedMilliseconds + "ms");
        }
        
        public static void Main(string[] args)
        {
            string input = @"15 14  1  4
            12  6  9  7
            2 11  8 13
            5  3 16 10";
            
            RunTest(input);
            Console.ReadKey(true);
            
//             string input2 = @"20 19 38 30 31 36 64 22
// 8 16 61 53 1 55 32 34
// 33 60 25 9 26 50 13 44
// 37 59 51 4 41 6 23 39
// 58 35 2 48 10 40 46 21
// 62 11 54 47 45 7 5 29
// 18 57 17 27 63 14 49 15
// 24 3 12 42 43 52 28 56";

//             RunTest(input2);
//             Console.ReadKey(true);
            
//             string input3 = @"63 19 22 37 28 8 47 36
// 45 23 43 53 11 34 18 33
// 41 62 46 27 5 24 42 13
// 32 56 31 12 64 20 6 39
// 16 60 3 7 17 59 54 44
// 21 30 14 50 35 2 57 51
// 4 9 61 25 48 58 26 29
// 38 1 40 49 52 55 10 15";

//             RunTest(input3);
//             Console.ReadKey(true);
            
//             string input4 = @"111 129 27 38 119 73 30 11 123 144 6 59
// 33 22 118 102 51 121 79 132 15 50 42 105
// 14 91 41 7 85 116 60 125 128 70 71 62
// 69 92 87 142 4 28 103 43 37 112 76 77
// 136 84 115 55 137 97 17 32 13 35 16 133
// 2 46 68 78 141 94 47 80 81 82 58 93
// 108 36 20 1 65 45 143 64 113 109 56 110
// 99 18 12 49 100 114 72 66 107 5 138 90
// 95 83 57 135 67 53 31 19 39 126 140 25
// 8 86 130 88 44 21 131 63 101 29 117 52
// 89 61 75 48 54 74 23 96 104 98 124 24
// 106 122 120 127 3 34 134 139 9 10 26 40";

//             RunTest(input4);
//             Console.ReadKey(true);
            
//             string input5 = @"183 209 124 52 167 165 57 56 47 180 198 232 60 76 121 129
// 62 116 82 10 225 114 70 213 184 246 249 112 201 41 37 94
// 205 208 39 83 138 151 132 38 26 87 69 211 186 251 109 123
// 139 245 181 119 68 182 115 122 238 1 173 8 16 137 73 239
// 13 12 91 156 226 196 144 192 51 223 145 45 193 117 172 80
// 110 17 244 237 134 21 159 96 86 242 74 206 84 162 43 141
// 195 113 5 127 200 29 250 107 185 157 255 176 18 108 104 27
// 229 42 148 101 30 120 61 158 152 252 219 35 203 63 189 54
// 136 217 85 243 34 214 199 111 147 3 58 36 174 53 253 93
// 236 48 216 234 194 103 32 81 97 99 75 20 100 190 98 233
// 19 40 125 2 128 230 241 163 256 67 7 235 140 177 14 212
// 50 254 248 143 142 28 88 131 6 64 133 95 118 231 220 105
// 65 11 126 150 166 228 207 171 247 78 23 191 59 102 161 71
// 66 168 164 187 92 77 224 130 90 9 135 106 227 175 4 202
// 188 210 153 15 33 154 31 215 155 178 22 179 55 24 240 204
// 160 146 25 197 79 44 46 72 89 170 221 169 222 149 218 49";

//             RunTest(input5);

            string input6 = @"161 43 265 55 169 201 241 284 234 192 20 200 221 337 311 176 92 137 286 385
363 281 290 242 344 141 121 199 215 283 143 144 261 73 125 373 116 130 145 21
71 372 191 90 134 153 148 333 177 41 278 139 110 151 358 275 198 366 263 162
335 356 203 64 247 76 258 94 129 306 316 27 60 188 288 204 376 276 11 196
338 277 323 78 83 95 49 61 307 245 54 183 246 365 113 396 327 168 273 29
158 69 187 364 86 287 155 236 259 186 182 79 37 238 132 217 103 315 328 392
354 52 2 142 70 254 383 285 53 296 314 264 233 271 362 212 124 106 81 152
58 322 208 75 31 260 190 87 357 295 57 400 269 150 303 7 341 42 351 207
149 343 331 223 85 24 165 329 32 39 397 300 257 274 140 220 99 225 377 1
391 19 136 120 301 15 164 249 65 318 166 346 230 138 339 272 175 167 299 100
213 317 184 367 387 210 375 115 35 193 72 102 91 348 38 374 80 321 18 170
180 111 325 156 218 361 89 378 104 36 393 47 235 44 63 289 28 388 394 171
50 93 74 389 381 46 268 14 308 16 309 231 282 126 304 371 297 17 194 240
146 135 370 380 26 119 248 294 267 243 147 206 117 173 324 122 270 45 23 355
280 88 237 345 108 347 251 298 214 34 154 205 330 163 4 66 227 279 252 128
127 13 224 266 232 157 313 12 253 350 319 114 302 5 384 68 256 369 67 179
22 352 96 293 195 291 209 59 211 109 292 399 98 160 62 202 305 360 244 51
222 320 25 9 189 395 228 185 310 368 133 262 97 398 8 33 239 77 172 340
336 250 255 178 390 219 48 112 379 342 159 30 353 82 40 10 226 216 3 382
56 197 84 174 334 359 107 386 101 118 105 332 181 326 312 123 131 6 229 349";

            RunTest(input6);

            string input7 = @"91 414 77 295 118 373 398 395 132 466 188 110 251 499 363 115 176 406 326 557 270 171 380 353
88 220 514 378 325 65 316 354 144 219 533 408 177 25 352 189 526 347 488 366 55 138 215 482
258 242 324 19 570 332 204 247 389 239 259 263 441 365 73 440 530 225 560 274 212 328 129 1
234 443 419 32 344 337 545 277 191 136 261 376 431 175 294 276 320 134 85 89 418 517 520 70
454 202 410 116 47 107 99 306 233 207 235 355 167 252 480 23 463 433 172 510 464 284 458 447
257 546 287 462 178 273 349 121 442 211 221 265 87 68 457 194 256 12 495 468 559 260 296 160
346 504 218 384 67 84 321 27 444 226 313 139 538 164 360 341 130 451 549 51 438 285 386 158
512 141 554 227 183 417 319 114 146 487 399 377 192 450 187 424 102 231 519 140 314 244 142 103
198 452 279 280 308 494 124 151 249 513 243 186 119 396 445 33 299 509 80 407 193 563 41 362
401 283 214 298 403 550 165 413 383 404 534 409 56 331 35 184 291 304 61 540 28 39 271 327
16 364 181 152 461 575 345 571 536 174 397 127 382 392 9 155 490 477 369 4 15 481 173 78
179 456 460 368 335 423 437 553 264 49 213 476 434 245 113 81 106 250 2 96 303 361 229 491
569 18 196 539 547 69 293 137 162 573 120 272 5 255 515 48 312 262 237 531 356 90 267 551
148 95 44 50 387 305 300 342 412 562 472 429 500 528 159 180 166 374 493 307 100 21 521 29
209 561 254 302 340 133 311 22 11 370 333 505 310 93 485 535 402 71 58 157 400 503 556 3
529 75 323 286 205 14 566 228 98 489 197 576 83 236 37 411 241 428 222 465 322 367 8 518
470 97 301 348 54 156 111 420 496 201 224 216 62 359 568 527 439 199 315 10 484 246 200 421
17 388 240 92 210 6 42 288 506 230 508 53 564 269 185 502 79 548 498 232 238 375 473 381
195 446 426 525 339 574 486 435 289 170 30 182 544 329 453 60 309 13 128 161 290 469 64 7
537 163 330 282 131 416 34 393 122 43 206 45 415 552 297 479 425 357 532 126 150 430 350 109
497 190 478 20 422 169 567 203 471 278 501 223 66 104 334 123 317 248 76 483 86 436 74 558
149 358 268 459 168 541 145 492 318 371 38 385 275 105 153 555 391 46 31 394 432 52 343 455
59 154 101 543 217 475 57 63 351 266 94 24 572 524 427 507 82 474 292 108 516 117 379 522
511 112 26 467 565 36 390 372 135 40 405 523 253 208 143 542 72 125 336 448 281 147 449 338";

            RunTest(input7);


            Console.ReadKey(true);
    
        }
    }
}
