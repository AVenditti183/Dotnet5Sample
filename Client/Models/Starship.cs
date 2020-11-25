using System;
using System.Drawing;
using System.ComponentModel.DataAnnotations;

namespace dotnet5sample.Client.Models
{
    public class Starship
    {
        [Required]
        [Range(typeof(Manufacturer), nameof(Manufacturer.SpaceX),nameof(Manufacturer.VirginGalactic), ErrorMessage = "Pick a manufacturer.")]
        public Manufacturer Manufacturer { get; set; } = Manufacturer.Unknown;

        [Required, EnumDataType(typeof(Color))]
        public Color? Color { get; set; } = null;

        [Required, EnumDataType(typeof(Engine))]
        public Engine? Engine { get; set; } = null;
    }

    public enum Manufacturer { SpaceX, NASA, ULA, VirginGalactic, Unknown }
    public enum Color { ImperialRed, SpacecruiserGreen, StarshipBlue, VoyagerOrange }
    public enum Engine { Ion, Plasma, Fusion, Warp }
}