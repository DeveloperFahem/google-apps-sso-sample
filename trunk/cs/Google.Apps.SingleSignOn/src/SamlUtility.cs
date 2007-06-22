// Copyright 2006 Google Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//      http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;

namespace Google.Apps.SingleSignOn
{
    /// <summary>
    /// Provides utility functions used in SAML processing.
    /// </summary>
    public static class SamlUtility
    {
        private static Random random = new Random();

        private static char[] charMapping = 
                { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p' };

        public static string CreateId()
        {
            byte[] bytes = new byte[20]; // 160 bits

            random.NextBytes(bytes);

            char[] chars = new char[40];

            for (int i = 0; i < bytes.Length; i++)
            {
                int left = (bytes[i] >> 4) & 0x0f;
                int right = bytes[i] & 0x0f;
                chars[i * 2] = charMapping[left];
                chars[i * 2 + 1] = charMapping[right];
            }

            return new string(chars);
        }
    }
}
