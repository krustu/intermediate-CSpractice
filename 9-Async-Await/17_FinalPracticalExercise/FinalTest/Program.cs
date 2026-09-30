using System;
class Program
{
    static async Task Main()
    {
        using var cts = new CancellationTokenSource();

        Console.CancelKeyPress += (sender, e) =>
        {
            e.Cancel = true;
            cts.Cancel();
        };
        List<RequestResult> errors = new();
        List<RequestResult> success = new();

        try
        {
            int index = 1;
            while (!cts.Token.IsCancellationRequested)
            {
                var Tasks = new List<Task<RequestResult>>()
                {
            Request1(cts.Token),
            Request2(cts.Token),
            Request3(cts.Token),

                };
                Task AllTasks = Task.WhenAll(Tasks);

                try
                {
                    await AllTasks;
                }
                catch (OperationCanceledException)
                {

                }


                foreach (var task in Tasks)
                {
                    if (task.Status == TaskStatus.RanToCompletion)
                    {
                        var result = task.Result;



                        if (result.Error != null)
                        {
                            result.Error = new Exception($"Error #{index}: {result.Error.Message}"
                                , result.Error);
                            errors.Add(result);
                            index++;
                        }


                        else
                        {
                            success.Add(result);
                        }
                    }
                }
                if (cts.Token.IsCancellationRequested)
                    break;

                await Task.Delay(2000, cts.Token);



            }


        }
        catch (OperationCanceledException ex)
        {
            Console.WriteLine(ex.Message);
        }
        finally
        {
            int c = 1;
            int b = 1;
            Console.WriteLine("Program closing...");
            Console.WriteLine($"Errors count - {errors.Count}");
            Console.WriteLine($"Success count - {success.Count}");

            Console.ReadKey();
            Console.WriteLine("list of error");
            foreach (var a in errors)
            {
                Console.WriteLine($"{c}- {a.Error.Message}");
                c++;
            }
            Console.WriteLine("list of sucess");
            foreach (var a in success)
            {
                Console.WriteLine($"{b}- {a.Value}");
                b++;
            }
        }


    }
    static async Task<RequestResult> Request1(CancellationToken Token)
    {
        try
        {
            if (Random.Shared.Next(0, 7) == 0)
            {
                throw new Exception("Request 1 - Failed!");
            }
            await Task.Delay(1000, Token);
            Console.WriteLine("Request 1 - completed");
            return new RequestResult
            {
                Value = "Request 1 - Success"
            };
        }
        catch (OperationCanceledException)
        {
            throw;
        }

        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new RequestResult
            {
                Error = ex
            };
        }
        finally
        {
            Console.WriteLine("Request1 closing..");
        }

    }
    static async Task<RequestResult> Request2(CancellationToken Token)
    {
        try
        {
            if (Random.Shared.Next(0, 4) == 0)
            {
                throw new Exception("Request 2 - Failed!");
            }

            await Task.Delay(2000, Token);
            Console.WriteLine("Request 2 - completed");
            return new RequestResult
            {
                Value = "Request 2 - Success"
            };
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new RequestResult
            {
                Error = ex
            };
        }
        finally
        {
            Console.WriteLine("Request2 closing..");
        }

    }
    static async Task<RequestResult> Request3(CancellationToken Token)
    {
        try
        {
            if (Random.Shared.Next(0, 6) == 0)
            {
                throw new Exception("Request 3 - Failed!");
            }
            await Task.Delay(3000, Token);
            Console.WriteLine("Request 3 - completed");
            return new RequestResult
            {
                Value = "Request 3 - Success"
            };
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            return new RequestResult
            {
                Error = ex
            };
        }
        finally
        {
            Console.WriteLine("Request3 closing..");
        }

    }
}
class RequestResult
{
    public string? Value { get; set; }
    public Exception? Error { get; set; }
}