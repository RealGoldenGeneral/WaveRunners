using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class FastFourierTransform : MonoBehaviour
{
    /* Implementation from https://github.com/tsantosfigueira/fast-fourier-transform
    * Reverses provided bits for a given length */
    public static int BitReverse(int n, int bits)
    {
        int reversedN = n;
        int count = bits + 1;

        n >>= 1;
        while (n > 0)
        {
            reversedN = (reversedN << 1) | (n & 1);
            count--;
            n >>= 1;
        }

        return ((reversedN << count) & ((1 << bits) - 1));
    }

    public static void Blackman(Complex[] buffer)
    {
        for (int i = 0; i < buffer.Length; i++)
        {
            double realNum = buffer[i].Real;
            realNum *= 0.42 - 0.5 * Math.Cos((2 * Math.PI * i) / buffer.Length) + 0.08 * Math.Cos((4 * Math.PI * i) / buffer.Length);
        }
    }

    /* Uses Cooley-Tukey iterative implementation of FFT
     * assumes no of points provided are a power of 2 */
    public static void FFT(Complex[] buffer)
    {
        int bits = (int)Math.Log(buffer.Length, 2);
        for (int j = 0; j < buffer.Length; j++)
        {
            int swapPos = BitReverse(j, bits);
            var temp = buffer[j];
            buffer[j] = buffer[swapPos];
            buffer[swapPos] = temp;
        }

        Blackman(buffer);

        for (int N =  2; N < buffer.Length; N <<= 1)
        {
            for (int i = 0; i < buffer.Length; i += N)
            {
                for (int k = 0; k < N / 2; k++)
                {
                    int evenIndex = i + k;
                    int oddIndex = i + k + (N / 2);
                    var even = buffer[evenIndex];
                    var odd = buffer[oddIndex];

                    double term = -2 * Math.PI * k / (double)N;
                    Complex exp = new Complex(Math.Cos(term), Math.Sin(term)) * odd;

                    buffer[evenIndex] = even + exp;
                    buffer[oddIndex] = even - exp;
                }
            }    
        }
    }
}
