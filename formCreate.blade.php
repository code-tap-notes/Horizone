<div class="form-group">
    <label class="list" for="rulingEn">@lang('dic.Ruling') @lang('dic.English') (<b style="color:red">*</b>)</label>
    <input type="text" name = "rulingEn" class="form-control" autocomplete="off" value="{{old('rulingEn')}}">
    @error('rulingEn')<p style="color:red">{{$message}}</p>@enderror
</div>
<div class="form-group">
    <label class="list" for="rulingFr">@lang('dic.Ruling') @lang('dic.French')</label>
    <input type="text" name = "rulingFr" class="form-control" autocomplete="off" value="{{old('rulingFr')}}">
     @error('rulingFr')<p style="color:red">{{$message}}</p>@enderror
</div>
<div class="form-group">
    <label class="list" for="rulingZh">@lang('dic.Ruling') @lang('dic.Chinese')</label>
    <input type="text" name = "rulingZh" class="form-control" autocomplete="off" value="{{old('rulingZh')}}">
     @error('rulingZh')<p style="color:red">{{$message}}</p>@enderror
</div>